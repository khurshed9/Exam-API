using Task = examAPI.Models.Task.Task;

namespace examAPI.Infrastructure.Services.TaskService;

public interface ITaskService
{
    Task<IEnumerable<Task>> GetTasks();
    
    Task<Task> GetTaskById(int taskId);
    
    Task<bool> CreateTask(Task task);
    
    Task<bool> UpdateTask(Task taskId);
    
    Task<bool> DeleteTask(int taskId);
}   