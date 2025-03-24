using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bai_tap_Advance.Properties.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public List<Category> Categories { get; set; } = new();
    }
}