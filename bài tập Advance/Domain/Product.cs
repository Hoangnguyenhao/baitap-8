namespace Domain;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; } = string.Empty;  
    public decimal Price { get; set; }

    public HashSet<Category> Categories { get; set; } = new();

    public Product() { }

    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
