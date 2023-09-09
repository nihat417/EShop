using MediatR;

namespace EShop.Application.Features.Commands.Orders.UpdateOrders
{
	public class UpdateOrdersRequest: IRequest<UpdateOrdersResponse>
	{
		public string OrderId { get; set; } = null!;
		public string Description { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string CustomerId { get; set; } = null!;
	}
}
