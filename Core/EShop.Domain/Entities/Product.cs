using EShop.Domain.Entities.Common;

namespace EShop.Domain.Entities
{
	public class Product : BaseEnitity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
