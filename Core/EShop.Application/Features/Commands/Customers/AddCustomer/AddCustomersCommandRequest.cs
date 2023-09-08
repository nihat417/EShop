using MediatR;

namespace EShop.Application.Features.Commands.Customers.AddCustomer
{
	public class AddCustomersCommandRequest : IRequest<AddCustomersCommandResponse>
	{
		public string CustomerName { get; set; } = null!;
	}
}
