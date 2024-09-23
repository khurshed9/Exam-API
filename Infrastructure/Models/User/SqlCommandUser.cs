namespace examAPI.Models.User;

public class SqlCommandUser
{
    public const string Insert = "INSERT INTO users(id,username,email,passwordHash,createdAt) values (@id,@username,@email,@passwordHash,@createdAt)";
    
    public const string Select = "SELECT * FROM users";
    
    public const string SelectByUserName = "SELECT * FROM users WHERE username = @userName";
    
    public const string Update = "UPDATE users SET id = @id, username=@username, email=@email, passwordHash=@passwordHash, createdAt = @createdAt WHERE username=@userName";
    
    public const string Delete = "DELETE FROM users WHERE username=@userName";
}