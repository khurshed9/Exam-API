namespace examAPI.Models.Comment.CommentQueries;

public class GetCommentOnTaskFilteredByUser
{
    public Guid Id { get; set; }

    public Guid TaskId { get; set; }

    public Guid UserId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}