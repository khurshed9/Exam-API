namespace examAPI.Models.Task;

public class SqlCommandTask
{
    public const string Insert =
        "INSERT INTO tasks(id,title,description,isCompleted,dueDate,userId,categoryId,priority,createdAt) values (@id,@title,@description,@isCompleted,@dueDate,@userId,@categoryId,@priority,@createdAt)";

    public const string Select = "Select * from tasks";
    
    public const string SelectById = "SELECT * FROM tasks WHERE id = @taskId";
    
    public const string Update = "UPDATE tasks SET id = @id, title = @title, description = @description, isCompleted = @isCompleted, dueDate = @dueDate, userId = @userId, categoryId = @categoryId, priority = @priority, createdAt = @createdAt WHERE id = @taskId";

    public const string Delete = "DELETE FROM tasks WHERE id = @taskId";
}