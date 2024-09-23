namespace examAPI.Infrastructure.Services.TaskService.TaskQueries;

public class GetTaskUserCategory
{
    public string Title { get; set; } = null!;

    public Guid UserId { get; set; }

    public string UserName { get; set; }=null!;

    public string Email { get; set; } = null!;

    public string PasswordHhash { get; set; } = null!;

    public DateTime UserCreatedAt { get; set; }

    public Guid CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public DateTime CategoryCreatedAt { get; set; }
}