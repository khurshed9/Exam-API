namespace examAPI.Infrastructure.Services.TaskAttachment;
using examAPI.Models.TaskAttachments;

public interface ITaskAttachmentService
{
    Task<IEnumerable<TaskAttachment>> GetTaskAttachments();
    
    Task<TaskAttachment?> GetTaskAttachmentById(int id);
    
    Task<bool> CreateTaskAttachment(TaskAttachment taskAttachment);
    
    Task<bool> UpdateTaskAttachment(TaskAttachment taskAttachment);
    
    Task<bool> DeleteTaskAttachment(int id);
}