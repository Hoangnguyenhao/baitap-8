using bai_tap_Advance.Properties.Data;
using bai_tap_Advance.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_tap_Advance.Properties.Services
{
    public class ProductService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Product>> SearchProductsAsync(string keyword)
        {
            var products = await _unitOfWork.Products.GetAllAsync();
            return products.Where(p => p.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }
    }
}
