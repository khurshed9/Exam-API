namespace examAPI.Models.TaskHistory;

public class TaskHistory
{
    public Guid Id { get; set; }
    
    public string ChangeDescription { get; set; } = null!;

    public DateTime ChangeAt { get; set; }

    public Guid TaskId { get; set; }
}