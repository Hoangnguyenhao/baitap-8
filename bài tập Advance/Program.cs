using Application;
using Domain;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

class Program
{
    static void Main()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseSqlServer("Server=.;Database=ProductDB;Trusted_Connection=True;")
            .Options;

        using var dbContext = new AppDbContext(options);
        var productRepo = new Repository<Product>(dbContext);
        var categoryRepo = new Repository<Category>(dbContext);
        var productService = new ProductService(productRepo, categoryRepo);

        while (true)
        {
            Console.WriteLine("\n1. Add Product\n2. Delete Product\n3. Search Products by Price Range\n4. Exit");
            Console.Write("Choose an option: ");
            var choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter product name: ");
                    string? name = Console.ReadLine()?.Trim();
                    Console.Write("Enter price: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal price) && !string.IsNullOrWhiteSpace(name))
                    {
                        productService.AddProduct(name, price);
                        Console.WriteLine("Product added successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid product name and price.");
                    }
                    break;

                case "2":
                    Console.Write("Enter product ID to delete: ");
                    if (int.TryParse(Console.ReadLine(), out int id))
                    {
                        productService.DeleteProduct(id);
                        Console.WriteLine("Product deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid product ID.");
                    }
                    break;

                case "3":
                    Console.Write("Enter min price: ");
                    bool minValid = decimal.TryParse(Console.ReadLine(), out decimal minPrice);
                    Console.Write("Enter max price: ");
                    bool maxValid = decimal.TryParse(Console.ReadLine(), out decimal maxPrice);

                    if (minValid && maxValid && minPrice <= maxPrice)
                    {
                        var products = productService.GetProductsByPriceRange(minPrice, maxPrice);
                        Console.WriteLine("Matching Products:");
                        foreach (var product in products)
                            Console.WriteLine($"- {product.Name} (${product.Price})");
                    }
                    else
                    {
                        Console.WriteLine("Invalid price range. Please enter valid min and max prices.");
                    }
                    break;

                case "4":
                    return;

                default:
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }
        }
    }
}
