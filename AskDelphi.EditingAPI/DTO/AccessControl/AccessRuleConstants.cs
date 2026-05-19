namespace AskDelphi.EditingAPI.DTO.AccessControl
{
    /// <summary>
    /// Constants used for access rule evaluation
    /// </summary>
    public static class AccessRuleConstants
    {
        /// <summary>
        /// Rule operator used to always use the claim
        /// </summary>
        public const string AccessRuleOperatorAlways = "always";
        /// <summary>
        /// Rule operator used to match claims equal to
        /// </summary>
        public const string AccessRuleOperatorIsEqual = "is-equal";
        /// <summary>
        /// Rule operator used to match claims not equal to
        /// </summary>
        public const string AccessRuleOperatorIsNotEqual = "is-not-equal";
        /// <summary>
        /// Rule operator used to match claims in 
        /// </summary>
        public const string AccessRuleOperatorIsIn = "is-in";
        /// <summary>
        /// Rule operator used to match claims not in
        /// </summary>
        public const string AccessRuleOperatorIsNotIn = "is-not-in";
        /// <summary>
        /// Rule operator used to match empty claims
        /// </summary>
        public const string AccessRuleOperatorIsEmpty = "is-empty";
        /// <summary>
        /// Rule operator used to match not empty claims
        /// </summary>
        public const string AccessRuleOperatorIsNotEmpty = "is-not-empty";
        /// <summary>
        /// Rule operator used to match claims containing
        /// </summary>
        public const string AccessRuleOperatorContains = "contains";
        /// <summary>
        /// Rule operator used to match claims not containing
        /// </summary>
        public const string AccessRuleOperatorNotContains = "not-contains";
        /// <summary>
        /// Rule operator used to match claims with matching
        /// </summary>
        public const string AccessRuleOperatorMatches = "matches";
        /// <summary>
        /// Rule operator used to match claims with not matching
        /// </summary>
        public const string AccessRuleOperatorNotMatches = "not-matches";

        /// <summary>
        /// When claim is matched indicates that access is allowed
        /// </summary>
        public const string AccessRuleRestrictionAllow = "allow";
        /// <summary>
        /// When claim is matched indicates that access is denied
        /// </summary>
        public const string AccessRuleRestrictionDeny = "deny";

    }
}
