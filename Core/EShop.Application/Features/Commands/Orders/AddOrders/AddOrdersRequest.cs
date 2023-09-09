using MediatR;

namespace EShop.Application.Features.Commands.Orders.AddOrders
{
	public class AddOrdersRequest:IRequest<AddOrdersResponse>
	{
		public string CustomerId { get; set; } = null!;
		public string Description { get; set; }= null!;
		public string Address { get; set; } = null!;
	}
}
