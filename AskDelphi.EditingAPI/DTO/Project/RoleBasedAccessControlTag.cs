namespace AskDelphi.EditingAPI.DTO.Project
{
    public class RoleBasedAccessControlTag
    {
        public string NodeId { get; set; }
        public string NodeName { get; set; }
        public string PathToParent { get; set; }
        public bool EnforcedByAcl { get; set; }
    }
}
