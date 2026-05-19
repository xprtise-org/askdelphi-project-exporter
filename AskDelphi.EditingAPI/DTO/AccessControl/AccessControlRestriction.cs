namespace AskDelphi.EditingAPI.DTO.AccessControl
{
    /// <summary>
    /// Contains information about access control restriction, used to identify if access control is applicable
    /// </summary>
    public class AccessControlRestriction
    {
        /// <summary>
        /// Claim name
        /// </summary>
        public string Claim { get; set; }
        /// <summary>
        /// Operator indicating how the restriction should be matched 
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// Indicates restriction type allow/deny
        /// </summary>
        public string RestrictionType { get; set; }
        /// <summary>
        /// Indicates that no further access control restrictions will considered once a match is found
        /// </summary>
        public bool StopProcessing { get; set; }
        /// <summary>
        /// Claim value
        /// </summary>
        public string Value { get; set; }
    }
}
