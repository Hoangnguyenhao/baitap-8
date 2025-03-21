using Domain;
using Infrastructure;
using System.Linq;

namespace Application;

public class ProductService
{
    private readonly IRepository<Product> _productRepository;
    private readonly IRepository<Category> _categoryRepository;

    public ProductService(IRepository<Product> productRepository, IRepository<Category> categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }

    public void AddProduct(string name, decimal price)
    {
        var product = new Product { Name = name, Price = price };
        _productRepository.Add(product);
    }

    public void DeleteProduct(int id)
    {
        var product = _productRepository.GetById(id);
        if (product is not null)
        {
            _productRepository.Remove(product);
            Directory.CreateDirectory("Logs");
            File.AppendAllText("Logs/log.txt", $"Deleted product: {product.Name} at {DateTime.Now}\n");
        }
    }

    public IEnumerable<Product> GetProductsByPriceRange(decimal minPrice, decimal maxPrice) =>
        _productRepository.GetAll().Where(p => p.Price >= minPrice && p.Price <= maxPrice);
}
