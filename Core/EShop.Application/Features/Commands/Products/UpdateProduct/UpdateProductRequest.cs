using MediatR;

namespace EShop.Application.Features.Commands.Products.UpdateProduct
{
	public class UpdateProductRequest:IRequest<UpdateProductResponse>
	{
		public string ProductId { get; set; } = null!;
		public string ProductName { get; set; } = null!;
		public string ProductDescription { get; set;} = null!;
		public decimal Price { get; set;}
		public int Stock { get; set;}
	}
}
