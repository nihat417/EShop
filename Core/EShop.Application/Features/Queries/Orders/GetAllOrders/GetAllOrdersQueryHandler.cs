using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Queries.Orders.GetAllOrders
{
	public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQueryRequest, GetAllOrdersQueryResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<GetAllOrdersQueryResponse> Handle(GetAllOrdersQueryRequest request, CancellationToken cancellationToken)
		{
			var order = unitOfWork.OrderReadRepository.GetAll(tracking:false);
			int count = order.Count();
			var SelectedOrders = order.OrderBy(p => p!.CreatedTime)
				.Skip(request.Count * request.Pagee)
				.Take(request.Count)
				.Select(orders =>new
				{
					orders!.Id,
					orders.Address,
					orders.Description,
					orders.CreatedTime,
				});
			return new() { Orders = SelectedOrders , TotalCount = count };
		}
	}
}
