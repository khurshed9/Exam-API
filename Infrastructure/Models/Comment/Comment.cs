namespace examAPI.Models.Comment;

public class Comment
{
    public Guid Id { get; set; }

    public string Content { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public Guid UserId { get; set; }

    public Guid TaskId{ get; set; }
}