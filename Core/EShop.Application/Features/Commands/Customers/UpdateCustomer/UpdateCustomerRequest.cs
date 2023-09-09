using MediatR;

namespace EShop.Application.Features.Commands.Customers.UpdateCustomer
{
	public class UpdateCustomerRequest:IRequest<UpdateCustomerResponse>
	{
		public string CustomerId { get; set; } = null!;
		public string CustomerName { get; set;} = null!;
	}
}
