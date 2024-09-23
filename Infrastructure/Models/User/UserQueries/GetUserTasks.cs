namespace examAPI.Models.User.UserQueries;

public class GetUserTasks
{
    public Guid UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime DueDate { get; set; }

    public string Priority { get; set; } = null!;
}