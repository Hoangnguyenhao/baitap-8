using bai_tap_Advance.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_tap_Advance.Properties.Data
{
    public class UnitOfWork
    {
        private readonly AppDbContext _context;
        public GenericRepository<Product> Products { get; }
        public GenericRepository<Category> Categories { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Products = new GenericRepository<Product>(_context);
            Categories = new GenericRepository<Category>(_context);
        }

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}