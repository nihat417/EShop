using MediatR;

namespace EShop.Application.Features.Commands.Orders.DeleteOrdes
{
	public class DeleteOrdersRequest:IRequest<DeleteOrdersResponse>
	{
		public string OrderId { get; set; } = null!;
	}
}
