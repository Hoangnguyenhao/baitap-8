using bai_tap_Advance.Properties.Data;
using bai_tap_Advance.Properties.Models;
using bai_tap_Advance.Properties.Services;
using bai_tap_Advance.Properties.Utils;

class Program
{
    static async Task Main(string[] args)
    {
        var dbContext = new AppDbContext();
        var unitOfWork = new UnitOfWork(dbContext);
        var productService = new ProductService(unitOfWork); 
        var categoryService = new CategoryService(unitOfWork); 

        while (true)
        {
            Console.WriteLine("===== QUAN LY SAN PHAM =====");
            Console.WriteLine("1. Them san pham");
            Console.WriteLine("2. Tim kiem san pham");
            Console.WriteLine("3. Xoa san pham");
            Console.WriteLine("4. Them danh muc");
            Console.WriteLine("5. Xem tat ca danh muc");
            Console.WriteLine("6. Xoa danh muc");
            Console.WriteLine("7. Thoat");

            Console.Write("Chon: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Ten san pham: ");
                    string productName = Console.ReadLine();
                    var product = new Product { Name = productName };
                    await unitOfWork.Products.AddAsync(product);
                    await unitOfWork.SaveChangesAsync();
                    Console.WriteLine("Da them san pham");
                    break;

                case "2":
                    Console.Write("Nhap tu khoa: ");
                    string keyword = Console.ReadLine();
                    var results = await productService.SearchProductsAsync(keyword);
                    if (!results.Any())
                    {
                        Console.WriteLine("Khong tim thay san pham nao");
                    }
                    else
                    {
                        foreach (var p in results)
                        {
                            Console.WriteLine($"ID: {p.Id}, Name: {p.Name}");
                        }
                    }
                    break;

                case "3":
                    Console.Write("Nhap ID san pham can xoa: ");
                    int productId = int.Parse(Console.ReadLine());
                    await unitOfWork.Products.DeleteAsync(productId);
                    await unitOfWork.SaveChangesAsync();
                    Logger.Log($"San pham co ID {productId} da bi xoa");
                    Console.WriteLine("Xoa thanh cong");
                    break;

                case "4":
                    Console.Write("Ten danh muc: ");
                    string categoryName = Console.ReadLine();
                    await categoryService.AddCategoryAsync(categoryName);
                    Console.WriteLine("Da them danh muc");
                    break;

                case "5":
                    var categories = await categoryService.GetAllCategoriesAsync();
                    if (!categories.Any())
                    {
                        Console.WriteLine("Khong co danh muc nao");
                    }
                    else
                    {
                        foreach (var c in categories)
                        {
                            Console.WriteLine($"ID: {c.Id}, Name: {c.Name}");
                        }
                    }
                    break;

                case "6":
                    Console.Write("Nhap ID danh muc can xoa: ");
                    int categoryId = int.Parse(Console.ReadLine());
                    await categoryService.DeleteCategoryAsync(categoryId);
                    Console.WriteLine("Xoa danh muc thanh cong");
                    break;

                case "7":
                    Console.WriteLine("Tam biet");
                    return;

                default:
                    Console.WriteLine("Lua chon khong hop le");
                    break;
            }
        }
    }
}
