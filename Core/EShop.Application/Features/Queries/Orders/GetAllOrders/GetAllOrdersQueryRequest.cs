using MediatR;

namespace EShop.Application.Features.Queries.Orders.GetAllOrders
{
	public class GetAllOrdersQueryRequest:IRequest<GetAllOrdersQueryResponse>
	{
		public int Pagee { get; set; } = 0;
		public int Count { get; set; } = 5;
	}
}
