namespace examAPI.Models.TaskAttachmentsSql;

public class SqlCommandTaskAttachment
{
    public const string Insert = "insert into taskAttachments(taskId,filepath,createdAt) values (@taskId,@filepath,@createdAt)";
    
    public const string Select = "select * from taskAttachments";
    
    public const string SelectById = "select * from taskAttachments where id = @Id";
    
    public const string Update = "update taskAttachments set id = @id, taskId=@taskId,filepath=@filepath,createdAt=@createdAt where id=@Id";
    
    public const string Delete = "delete from taskAttachments where id = @Id";
}