namespace examAPI.Models.TaskAttachments;

public class TaskAttachment
{
    public Guid Id { get; set; }

    public string FilePath { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public Guid TaskId { get; set; }
}