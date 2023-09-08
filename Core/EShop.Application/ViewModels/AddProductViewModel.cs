using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Application.ViewModels
{
    public class AddProductViewModel
    {
        public string Name { get; set; } = null!;
        public string Desc { get; set; } = null!;
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
