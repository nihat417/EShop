using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Queries.Customers.GetAllCustomers
{
	public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, GetCustomersQueryResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public GetCustomersQueryHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<GetCustomersQueryResponse> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
		{
			var customers = unitOfWork.CustomerReadRepository.GetAll(tracking: false);
			var total = customers.Count();

			var selecetedCustomers = customers
						.OrderBy(p => p!.CreatedTime)
						.Skip(request.Size * request.Page)
						.Take(request.Size)
						.Select(p => new
						{
							p!.Id,
							p!.Name,
							p!.CreatedTime,
						});
			return new() { Customers = selecetedCustomers , TotalCount = total };
		}
	}
}
