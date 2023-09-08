using MediatR;

namespace EShop.Application.Features.Commands.Products.DeleteProduct
{
	public class DeleteProductRequest:IRequest<DeleteProductResponse>
	{
		public string Id { get; set; } 
	}
}
