namespace examAPI.Models.Comment;

public class SqlCommandComment
{
    public const string Insert = "INSERT INTO comments(id,taskId,userId,content,createdAt) values (@id,@taskId,@userId,@content,@createdAt)";
    
    public const string SelectById = "SELECT * FROM comments WHERE Id = @commmentId";
    
    public const string Delete = "DELETE FROM comments WHERE Id = @commentId";
    
    public const string Update = "UPDATE comments SET id = @id, taskId = @taskId, userId = @userId, content = @content, createdAt = @createdAt WHERE Id = @commentId";
    
    public const string Select = "SELECT * FROM comments";
    
}