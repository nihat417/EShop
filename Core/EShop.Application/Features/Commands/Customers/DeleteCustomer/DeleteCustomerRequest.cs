using MediatR;

namespace EShop.Application.Features.Commands.Customers.DeleteCustomer
{
	public class DeleteCustomerRequest:IRequest<DeleteCustomerResponse>
	{
		public string CustomerId { get; set; } = null!;
	}
}
