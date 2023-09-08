using MediatR;

namespace EShop.Application.Features.Queries.Customers.GetAllCustomers
{
	public class GetCustomersQueryRequest : IRequest<GetCustomersQueryResponse>
	{
		public int Page { get; set; } = 0;
		public int Size { get; set; } = 5;
	}
}
