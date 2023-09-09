using EShop.Application.Features.Commands.Customers.DeleteCustomer;
using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Commands.Orders.DeleteOrdes
{
	public class DeleteOrdersHandler:IRequestHandler<DeleteOrdersRequest, DeleteOrdersResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public DeleteOrdersHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<DeleteOrdersResponse> Handle(DeleteOrdersRequest request, CancellationToken cancellationToken)
		{
			var orders = await unitOfWork.OrderReadRepository.GetAsync(request.OrderId);
			if (orders != null)
			{
				unitOfWork.OrderWriteRepository.Remove(orders);
				await unitOfWork.OrderWriteRepository.SaveChangesAsync();
				return new() { Success = true };
			}
			return new() { Success = false };
		}
	}
}
