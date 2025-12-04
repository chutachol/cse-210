public class Comment
{
    private string _commenterName;
    private string _commentText;
    private DateTime _datePosted;

    public Comment(string commenterName, string commentText)
    {
        _commenterName = commenterName;
        _commentText = commentText;
        _datePosted = DateTime.Now;
    }

    // Constructor with custom date (for testing/demo purposes)
    public Comment(string commenterName, string commentText, DateTime datePosted)
    {
        _commenterName = commenterName;
        _commentText = commentText;
        _datePosted = datePosted;
    }

    // Method to get comment details
    public string GetCommentDetails()
    {
        return $"  {_commenterName} (on {_datePosted.ToString("yyyy-MM-dd")}):\n  \"{_commentText}\"";
    }

    // Properties for access if needed
    public string CommenterName { get { return _commenterName; } }
    public string CommentText { get { return _commentText; } }
    public DateTime DatePosted { get { return _datePosted; } }
}