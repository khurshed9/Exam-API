namespace examAPI.Models.Category;

public class SqlCommandCategory
{
    public const string Insert = "INSERT INTO categories(id,name,createdAt) values (@id,@name,@createdAt)";
    
    public const string Select = "SELECT * FROM categories";
    
    public const string Update = "UPDATE categories set id = @idname = @name,createdAt = @createdAt WHERE name = @name";
    
    public const string Delete = "DELETE FROM categories WHERE name = @name";
    
    public const string SelectByName = "SELECT * FROM categories WHERE name = @name";
}