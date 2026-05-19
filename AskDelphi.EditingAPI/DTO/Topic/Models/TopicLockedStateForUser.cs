namespace AskDelphi.EditingAPI.DTO.Topic.Models
{
    public enum TopicLockedStateForUser
    {
        New, // topic is new (deprecated)
        CheckedIn, // topic is checkedin
        CheckedOutByCurrentUser, // topic is checked out by the current user
        CheckedOutByDifferentUser // topic is checked out by another user

    }
}
