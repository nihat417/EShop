using MediatR;

namespace EShop.Application.Features.Commands.Products.AddProduct
{
	public class AddProductCommandRequest : IRequest<AddProductCommandResponse>
	{
		public string ProductName { get; set; } = null!;
		public string ProductDescription { get; set; } = null!;
		public decimal Price { get; set; }
		public int Stock { get; set; }
	}
}
