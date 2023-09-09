using EShop.Application.Repositories;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Features.Commands.Orders.AddOrders
{
	public class AddOrdersHandler : IRequestHandler<AddOrdersRequest, AddOrdersResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public AddOrdersHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<AddOrdersResponse> Handle(AddOrdersRequest request, CancellationToken cancellationToken)
		{
			var customer = await unitOfWork.CustomerReadRepository.GetAsync(request.CustomerId);
			if (customer != null)
			{
				var orders = new Order()
				{
					Id = Guid.NewGuid(),
					Address = request.Address,
					Description = request.Description,
					Customer = customer,
					CreatedTime = DateTime.Now,
				};
				await unitOfWork.OrderWriteRepository.AddAsync(orders);
				await unitOfWork.OrderWriteRepository.SaveChangesAsync();
				return new();
			}
			return new();
		}
	}
}
