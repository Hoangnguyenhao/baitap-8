namespace Domain;

public class Category
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;
    public HashSet<Product> Products { get; set; } = new();

    public Category() { }

    public Category(string name) => Name = name;
}
