namespace examAPI.Infrastructure.Services.TaskService.TaskQueries;

public class GetTaskByCompletionDate
{
    public Guid Id { get; set; } 

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsCompleted { get; set; } = false;

    public DateTime DueDate { get; set; }

    public string Priority { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public Guid UserId { get; set; }

    public Guid CategoryId { get; set; }
}