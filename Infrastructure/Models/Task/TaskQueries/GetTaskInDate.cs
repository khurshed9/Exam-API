namespace examAPI.Infrastructure.Services.TaskService.TaskQueries;

public class GetTaskInDate
{
    public Guid Id{ get; set; }

    public string Ttile { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime DueDate { get; set; }

    public Guid UserId{ get; set; }

    public Guid CategoryId { get; set; }

    public string Priority { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
}