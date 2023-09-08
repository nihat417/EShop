using MediatR;

namespace EShop.Application.Features.Queries.Products.GetAllProducts
{
	public class GetProductsQueryRequest :IRequest<GetProductsQueryResponse>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
