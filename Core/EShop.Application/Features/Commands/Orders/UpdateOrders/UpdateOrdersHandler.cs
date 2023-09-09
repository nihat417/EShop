using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Commands.Orders.UpdateOrders
{
	public class UpdateOrdersHandler:IRequestHandler<UpdateOrdersRequest, UpdateOrdersResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public UpdateOrdersHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<UpdateOrdersResponse> Handle(UpdateOrdersRequest request, CancellationToken cancellationToken)
		{
			var orders = await unitOfWork.OrderReadRepository.GetAsync(request.OrderId);
			var customer = await unitOfWork.CustomerReadRepository.GetAsync(request.CustomerId);
			if (orders != null)
			{
				orders!.Address = request.Address;
				orders.Description = request.Description;
				orders.Customer = customer;
				unitOfWork.OrderWriteRepository.Update(orders);
				await unitOfWork.OrderWriteRepository.SaveChangesAsync();
				return new() { Success = true };
			}
			return new() { Success = false };
		}
	}
}
