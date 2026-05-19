namespace AskDelphi.EditingAPI.DTO.Editors
{
    /// <summary>
    /// Object describing file value
    /// </summary>
    public class FileValueData
    {
        /// <summary>
        /// Resource unique id used to extract SAS URI from backend
        /// </summary>
        public Guid ResourceId { get; set; }
        /// <summary>
        /// Default file, legacy
        /// </summary>
        public string DefaultFile { get; set; }
        /// <summary>
        /// File mimy-type
        /// </summary>
        public string MimeType { get; set; }
        /// <summary>
        /// SHA1 of the resource stream
        /// </summary>
        public string ResourceSHA1 { get; set; }
        /// <summary>
        /// File name with extension
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Only for image resources this is the base64 of the resource stream
        /// </summary>
        public string ThumbnailImageBase64 { get; set; }

        /// <summary>
        /// Indicates if file is external
        /// </summary>
        public bool IsExternal { get; set; }

        /// <summary>
        /// Id of external adapter
        /// </summary>
        public string AdapterId { get; set; }

        /// <summary>
        /// External resource id
        /// </summary>
        public string ExternalResourceId { get; set; }
    }
}
