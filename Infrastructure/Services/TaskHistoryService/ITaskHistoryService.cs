namespace examAPI.Infrastructure.Services.TaskHistory;
using examAPI.Models.TaskHistory;

public interface ITaskHistoryService
{
    Task<IEnumerable<TaskHistory>> GetTasksHistory();
    
    Task<TaskHistory> GetTaskHistoryById(int id);
    
    Task<bool> CreateTaskHistory(TaskHistory taskHistory);
    
    Task<bool> UpdateTaskHistory(TaskHistory taskHistory);
    
    Task<bool> DeleteTaskHistory(int id);
}