namespace examAPI.Models.TaskHistory;

public class SqlCommandTaskHistory
{
    public const string Insert = "INSERT INTO taskHistory";
    
    public const string Select = "SELECT * FROM taskHistory";
    
    public const string SelectById = "SELECT * FROM taskHistory WHERE id = @Id";
    
    public const string Update = "UPDATE taskHistory SET id = @id, taskId = @taskId, changeDescription = @changeDescription, changedAt = @changedAt WHERE id = @Id";
    
    public const string Delete = "DELETE FROM taskHistory WHERE id = @id";
}