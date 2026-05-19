using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using AskDelphi.ProjectPublisher;
using AskDelphi.JSONExport;
using AskDelphi.JSONExport.DTO;
using AskDelphi.JSONExport.Output;
using AskDelphi.EditingAPI;
using AskDelphi.EditingAPI.Authenticators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Win32;
using RestSharp;
using static AskDelphi.ProjectPublisher.PublicationSettings;

namespace AdPublisherUI
{
    public partial class MainWindow : Window
    {
        private Options _options = new();
        private bool _isRunning = false;

        public MainWindow()
        {
            InitializeComponent();
            LoadOptionsToUI();
        }

        private void LoadOptionsToUI()
        {
            txtAuthFile.Text = _options.AuthenticationDataFile;
            txtSecretFile.Text = _options.SecretFile;
            txtOptionsFile.Text = _options.OptionsFilename;
            txtTenantGuid.Text = _options.TenantGuid.ToString();
            txtAclGuid.Text = _options.ACLGuid.ToString();
            txtWorkflowStage.Text = _options.WorkflowStageTitle;
            txtProjectGuid.Text = _options.ProjectGuid.ToString();
            txtApiUrl.Text = _options.EditingAPIBaseUrl;
            txtOutFolder.Text = _options.OutFolder;
            txtSessionCode.Text = _options.SessionCode;
            txtBaseUrl.Text = _options.BaseURL;
            txtOutContainerUri.Text = _options.OutContainerURI;
            UpdateContentSetList();
        }

        private void UpdateContentSetList()
        {
            lstContentSet.Items.Clear();
            if (_options.ContentSet != null)
            {
                foreach (var rule in _options.ContentSet)
                {
                    lstContentSet.Items.Add(GetRuleSummary(rule));
                }
            }
        }

        private string GetRuleSummary(RuleConfiguration rule)
        {
            return rule.Type switch
            {
                RuleConfiguration.RuleType.IncludeSpecificTopic => $"Include Specific Topic: {rule.IncludeSpecificTopic?.TopicGuid}",
                RuleConfiguration.RuleType.IncludeRelatedTopics => $"Include Related Topics: MaxDepth={rule.IncludeRelatedTopics?.MaxDepth}",
                RuleConfiguration.RuleType.IncludeAll => "Include All",
                RuleConfiguration.RuleType.IncludeTopicsOfNamespace => $"Include Topics of Namespace: {rule.IncludeTopicsOfNamespace?.Namespace}",
                RuleConfiguration.RuleType.IncludeTopicsOfType => $"Include Topics of Type: {rule.IncludeTopicsOfType?.TopicTypeGuid}",
                RuleConfiguration.RuleType.IncludeTopicsWithTag => $"Include Topics with Tag: {rule.IncludeTopicsWithTag?.HierarchyName}, {rule.IncludeTopicsWithTag?.Tag}",
                _ => "None"
            };
        }

        private void SaveOptionsFromUI()
        {
            _options.AuthenticationDataFile = txtAuthFile.Text;
            _options.SecretFile = txtSecretFile.Text;
            _options.OptionsFilename = txtOptionsFile.Text;
            if (Guid.TryParse(txtTenantGuid.Text, out var tenantGuid)) _options.TenantGuid = tenantGuid;
            if (Guid.TryParse(txtAclGuid.Text, out var aclGuid)) _options.ACLGuid = aclGuid;
            _options.WorkflowStageTitle = txtWorkflowStage.Text;
            if (Guid.TryParse(txtProjectGuid.Text, out var projectGuid)) _options.ProjectGuid = projectGuid;
            _options.EditingAPIBaseUrl = txtApiUrl.Text;
            _options.OutFolder = txtOutFolder.Text;
            _options.SessionCode = txtSessionCode.Text;
            _options.BaseURL = txtBaseUrl.Text;
            _options.OutContainerURI = txtOutContainerUri.Text;
            // ContentSet is managed separately
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog { Filter = "JSON files (*.json)|*.json" };
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog.FileName);
                    _options = JsonSerializer.Deserialize<Options>(json) ?? new Options();
                    LoadOptionsToUI();
                    MessageBox.Show("Loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading: {ex.Message}");
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveOptionsFromUI();
            var saveFileDialog = new SaveFileDialog { Filter = "JSON files (*.json)|*.json" };
            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    var json = JsonSerializer.Serialize(_options, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(saveFileDialog.FileName, json);
                    MessageBox.Show("Saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error saving: {ex.Message}");
                }
            }
        }

        private void btnBrowseAuthFile_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog { Filter = "JSON files (*.json)|*.json", Title = "Select Auth File Location" };
            if (saveFileDialog.ShowDialog() == true)
            {
                txtAuthFile.Text = saveFileDialog.FileName;
            }
        }

        private void btnBrowseOutFolder_Click(object sender, RoutedEventArgs e)
        {
            // Workaround for folder selection using OpenFileDialog (since FolderBrowserDialog isn't available without System.Windows.Forms)
            var openFileDialog = new OpenFileDialog
            {
                Title = "Select Output Folder (navigate to folder and select any file inside it)",
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Folder Selection" // Placeholder; user will select a file in the desired folder
            };
            if (openFileDialog.ShowDialog() == true)
            {
                // Extract the directory from the selected file path
                txtOutFolder.Text = Path.GetDirectoryName(openFileDialog.FileName);
            }
        }

        private async void btnAuthenticateNow_Click(object sender, RoutedEventArgs e)
        {
            SaveOptionsFromUI();
            if (string.IsNullOrWhiteSpace(txtSessionCode.Text) || string.IsNullOrWhiteSpace(txtAuthFile.Text))
            {
                MessageBox.Show("Session Code and Auth File must be set.");
                return;
            }
            try
            {
                var model = await GetSessionRegistrationFromPortalAsync(txtSessionCode.Text);
                WriteAuthenticationData(_options, model);
                MessageBox.Show("Authentication data initialized.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication failed: {ex.Message}");
            }
        }

        private async void btnRunNow_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning) return;
            _isRunning = true;
            btnRunNow.IsEnabled = false;

            SaveOptionsFromUI();
            _options = InitializeOptions(_options);

            var progressDialog = new ProgressDialog();
            progressDialog.Owner = this;
            progressDialog.Show();

            try
            {
                await PublishAsync(_options);
                progressDialog.Close();
                MessageBox.Show("Publication completed.");
            }
            catch (Exception ex)
            {
                progressDialog.Close();
                MessageBox.Show($"Error: {ex.Message}");
            }
            finally
            {
                _isRunning = false;
                btnRunNow.IsEnabled = true;
            }
        }

        private async Task PublishAsync(Options options)
        {
            if (!string.IsNullOrWhiteSpace(options.OutFolder)) Directory.CreateDirectory(options.OutFolder);

            var builder = Host.CreateApplicationBuilder();
            builder.Services.AddLogging();
            builder.Services.AddAskDelphiEditingAPI();
            builder.Services.AddAskdelphiPublisherFramework(new PublicationSettings
            {
                BaseURL = options.BaseURL ?? "http://tempuri.org/url=not-set",
                BasePath = options.OutFolder ?? ".",
                TenantGuid = options.TenantGuid,
                ProjectGuid = options.ProjectGuid,
                AclGuid = options.ACLGuid,
                WorkflowStageTitle = options.WorkflowStageTitle ?? "Publish",
                ContentSet = options.ContentSet ?? [new() { Type = RuleConfiguration.RuleType.IncludeTopicsOfNamespace, IncludeTopicsOfNamespace = new() { Namespace = "http://tempuri.org/imola-skill-area" } }],
            });

            if (!string.IsNullOrWhiteSpace(options.SecretFile) && File.Exists(options.SecretFile))
            {
                builder.Services.AddSingleton(JsonSerializer.Deserialize<SecretsBasedAuthenticatorOptions>(File.ReadAllText(options.SecretFile)) ?? new());
                builder.Services.AddSingleton<IAdAPIAuthenticator, SecretBasedAuthenticator>();
            }
            else if (!string.IsNullOrWhiteSpace(options.AuthenticationDataFile) && File.Exists(options.AuthenticationDataFile))
            {
                builder.Services.AddSingleton(JsonSerializer.Deserialize<BearerTokenAuthenticatorOptions>(File.ReadAllText(options.AuthenticationDataFile)) ?? new());
                builder.Services.AddSingleton<IAdAPIAuthenticator, BearerTokenAuthenticator>();
            }

            builder.Services.AddSingleton<IPublicationTargetFilesystem, LocalFolderStore>();
            builder.Services.AddTopicPublishers();
            builder.Services.AddTransient<IPublicationFinalizer, PublicationProcessFinalizer>();

            using var host = builder.Build();
            var context = new AskdelphiPublisherContext
            {
                AclGuid = options.ACLGuid,
                ProjectGuid = options.ProjectGuid,
                TenantGuid = options.TenantGuid,
                URL = options.EditingAPIBaseUrl?.Trim('/') ?? "https://edit.api.askdelphi.com",
                Authenticator = host.Services.GetRequiredService<IAdAPIAuthenticator>(),
                ContentSet = options.ContentSet,
            };

            var publisher = host.Services.GetRequiredService<IAskDelphiProjectPublisher>();
            var result = await publisher.Publish(context);
            await host.StopAsync();
        }

        private void btnAddRule_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new RuleWindow();
            if (dialog.ShowDialog() == true)
            {
                _options.ContentSet ??= new List<RuleConfiguration>();
                _options.ContentSet.Add(dialog.Rule);
                UpdateContentSetList();
            }
        }

        private void btnRemoveRule_Click(object sender, RoutedEventArgs e)
        {
            if (lstContentSet.SelectedIndex >= 0)
            {
                _options.ContentSet?.RemoveAt(lstContentSet.SelectedIndex);
                UpdateContentSetList();
            }
        }

        private void lstContentSet_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (lstContentSet.SelectedIndex >= 0 && _options.ContentSet != null)
            {
                var dialog = new RuleWindow(_options.ContentSet[lstContentSet.SelectedIndex]);
                if (dialog.ShowDialog() == true)
                {
                    _options.ContentSet[lstContentSet.SelectedIndex] = dialog.Rule;
                    UpdateContentSetList();
                }
            }
        }

        // Copied from Program.cs for authentication
        private static async Task<RegistrationModel> GetSessionRegistrationFromPortalAsync(string sessionCode)
        {
            var portalClientOptions = new RestClientOptions("https://portal.askdelphi.com") { ThrowOnAnyError = true };
            var portalClient = new RestClient(portalClientOptions);
            var portalRequest = new RestRequest("api/session/registration");
            portalRequest.AddQueryParameter("sessionCode", sessionCode);
            var response = await portalClient.GetAsync<RegistrationModel>(portalRequest);
            return response ?? new();
        }

        private static void WriteAuthenticationData(Options options, RegistrationModel model)
        {
            if (!String.IsNullOrWhiteSpace(Path.GetDirectoryName(options.AuthenticationDataFile ?? "")))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(options.AuthenticationDataFile ?? "") ?? ".");
            }
            var bta = new BearerTokenAuthenticatorOptions
            {
                RefreshToken = model.RefreshToken,
                Token = model.AccessToken,
                TokenFilename = Path.GetFullPath(options.AuthenticationDataFile ?? ""),
                URL = model.Url
            };
            File.WriteAllText(options.AuthenticationDataFile ?? "auth.json", JsonSerializer.Serialize(bta));
        }

        private static Options InitializeOptions(Options options)
        {
            options.SessionCode = null;
            if (!string.IsNullOrWhiteSpace(options.OptionsFilename) && File.Exists(options.OptionsFilename))
            {
                var defaultOptions = JsonSerializer.Deserialize<Options>(File.ReadAllText(options.OptionsFilename));
                options = defaultOptions ?? options;
            }
            else if (!string.IsNullOrWhiteSpace(options.OptionsFilename))
            {
                File.WriteAllText(options.OptionsFilename, JsonSerializer.Serialize(options));
            }
            return options;
        }
    }

    // Simple window for adding/editing rules
    public partial class RuleWindow : Window
    {
        public RuleConfiguration Rule { get; private set; }

        private ComboBox cmbType;
        private TextBox txtData1, txtData2;
        private Label lblData1, lblData2;
        private Button btnOk, btnCancel;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        public RuleWindow(RuleConfiguration? existing = null)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
        {
            Rule = existing ?? new RuleConfiguration { Type = RuleConfiguration.RuleType.None };
            InitializeComponents();
            LoadRule();
        }

        private void InitializeComponents()
        {
            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(200) });

            cmbType = new ComboBox { ItemsSource = Enum.GetValues(typeof(RuleConfiguration.RuleType)), SelectedIndex = 0 };
            Grid.SetRow(cmbType, 0);
            Grid.SetColumn(cmbType, 1);

            lblData1 = new Label { Content = "" };
            Grid.SetRow(lblData1, 1);
            Grid.SetColumn(lblData1, 0);
            txtData1 = new TextBox();
            Grid.SetRow(txtData1, 1);
            Grid.SetColumn(txtData1, 1);

            lblData2 = new Label { Content = "" };
            Grid.SetRow(lblData2, 2);
            Grid.SetColumn(lblData2, 0);
            txtData2 = new TextBox();
            Grid.SetRow(txtData2, 2);
            Grid.SetColumn(txtData2, 1);

            btnOk = new Button { Content = "OK", IsDefault = true };
            btnOk.Click += (s, e) => DialogResult = true;
            Grid.SetRow(btnOk, 3);
            Grid.SetColumn(btnOk, 0);

            btnCancel = new Button { Content = "Cancel", IsCancel = true };
            btnCancel.Click += (s, e) => DialogResult = false;
            Grid.SetRow(btnCancel, 3);
            Grid.SetColumn(btnCancel, 1);

            grid.Children.Add(cmbType);
            grid.Children.Add(lblData1);
            grid.Children.Add(txtData1);
            grid.Children.Add(lblData2);
            grid.Children.Add(txtData2);
            grid.Children.Add(btnOk);
            grid.Children.Add(btnCancel);

            Content = grid;
            Title = "Edit Rule";
            Width = 300;
            Height = 200;
            cmbType.SelectionChanged += CmbType_SelectionChanged;
        }

        private void LoadRule()
        {
            cmbType.SelectedItem = Rule.Type;
            UpdateFields();
            switch (Rule.Type)
            {
                case RuleConfiguration.RuleType.IncludeSpecificTopic:
                    txtData1.Text = Rule.IncludeSpecificTopic?.TopicGuid.ToString();
                    break;
                case RuleConfiguration.RuleType.IncludeRelatedTopics:
                    txtData1.Text = Rule.IncludeRelatedTopics?.MaxDepth.ToString();
                    break;
                case RuleConfiguration.RuleType.IncludeTopicsOfNamespace:
                    txtData1.Text = Rule.IncludeTopicsOfNamespace?.Namespace;
                    break;
                case RuleConfiguration.RuleType.IncludeTopicsOfType:
                    txtData1.Text = Rule.IncludeTopicsOfType?.TopicTypeGuid.ToString();
                    break;
                case RuleConfiguration.RuleType.IncludeTopicsWithTag:
                    txtData1.Text = Rule.IncludeTopicsWithTag?.HierarchyName;
                    txtData2.Text = Rule.IncludeTopicsWithTag?.Tag;
                    break;
            }
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rule.Type = (RuleConfiguration.RuleType)cmbType.SelectedItem;
            UpdateFields();
        }

        private void UpdateFields()
        {
            switch (Rule.Type)
            {
                case RuleConfiguration.RuleType.IncludeSpecificTopic:
                    lblData1.Content = "Topic GUID:";
                    lblData1.Visibility = Visibility.Visible;
                    txtData1.Visibility = Visibility.Visible;
                    lblData2.Visibility = Visibility.Collapsed;
                    txtData2.Visibility = Visibility.Collapsed;
                    break;
                case RuleConfiguration.RuleType.IncludeRelatedTopics:
                    lblData1.Content = "Max Depth:";
                    lblData1.Visibility = Visibility.Visible;
                    txtData1.Visibility = Visibility.Visible;
                    lblData2.Visibility = Visibility.Collapsed;
                    txtData2.Visibility = Visibility.Collapsed;
                    break;
                case RuleConfiguration.RuleType.IncludeAll:
                    lblData1.Visibility = Visibility.Collapsed;
                    txtData1.Visibility = Visibility.Collapsed;
                    lblData2.Visibility = Visibility.Collapsed;
                    txtData2.Visibility = Visibility.Collapsed;
                    break;
                case RuleConfiguration.RuleType.IncludeTopicsOfNamespace:
                    lblData1.Content = "Namespace:";
                    lblData1.Visibility = Visibility.Visible;
                    txtData1.Visibility = Visibility.Visible;
                    lblData2.Visibility = Visibility.Collapsed;
                    txtData2.Visibility = Visibility.Collapsed;
                    break;
                case RuleConfiguration.RuleType.IncludeTopicsOfType:
                    lblData1.Content = "Topic Type GUID:";
                    lblData1.Visibility = Visibility.Visible;
                    txtData1.Visibility = Visibility.Visible;
                    lblData2.Visibility = Visibility.Collapsed;
                    txtData2.Visibility = Visibility.Collapsed;
                    break;
                case RuleConfiguration.RuleType.IncludeTopicsWithTag:
                    lblData1.Content = "Hierarchy Name:";
                    lblData1.Visibility = Visibility.Visible;
                    txtData1.Visibility = Visibility.Visible;
                    lblData2.Content = "Tag:";
                    lblData2.Visibility = Visibility.Visible;
                    txtData2.Visibility = Visibility.Visible;
                    break;
                default: // None
                    lblData1.Visibility = Visibility.Collapsed;
                    txtData1.Visibility = Visibility.Collapsed;
                    lblData2.Visibility = Visibility.Collapsed;
                    txtData2.Visibility = Visibility.Collapsed;
                    break;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            if (DialogResult == true)
            {
                Rule = new RuleConfiguration { Type = (RuleConfiguration.RuleType)cmbType.SelectedItem };
                switch (Rule.Type)
                {
                    case RuleConfiguration.RuleType.IncludeSpecificTopic:
                        if (Guid.TryParse(txtData1.Text, out var guid)) Rule.IncludeSpecificTopic = new() { TopicGuid = guid };
                        break;
                    case RuleConfiguration.RuleType.IncludeRelatedTopics:
                        if (int.TryParse(txtData1.Text, out var depth)) Rule.IncludeRelatedTopics = new() { MaxDepth = depth };
                        break;
                    case RuleConfiguration.RuleType.IncludeTopicsOfNamespace:
                        Rule.IncludeTopicsOfNamespace = new() { Namespace = txtData1.Text };
                        break;
                    case RuleConfiguration.RuleType.IncludeTopicsOfType:
                        if (Guid.TryParse(txtData1.Text, out guid)) Rule.IncludeTopicsOfType = new() { TopicTypeGuid = guid };
                        break;
                    case RuleConfiguration.RuleType.IncludeTopicsWithTag:
                        Rule.IncludeTopicsWithTag = new() { HierarchyName = txtData1.Text, Tag = txtData2.Text };
                        break;
                }
            }
            base.OnClosing(e);
        }
    }
}