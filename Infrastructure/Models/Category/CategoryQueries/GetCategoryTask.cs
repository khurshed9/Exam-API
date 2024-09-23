namespace examAPI.Models.Category.CategoryQueries;

public class GetCategoryTask
{
    public Guid CategoryId { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int Sum { get; set; }
}