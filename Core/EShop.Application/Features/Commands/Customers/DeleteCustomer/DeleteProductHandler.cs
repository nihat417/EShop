using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Commands.Customers.DeleteCustomer
{
	public class DeleteProductHandler : IRequestHandler<DeleteCustomerRequest, DeleteCustomerResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public DeleteProductHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<DeleteCustomerResponse> Handle(DeleteCustomerRequest request, CancellationToken cancellationToken)
		{
			var customer = await unitOfWork.CustomerReadRepository.GetAsync(request.CustomerId);
			if (customer != null)
			{
				unitOfWork.CustomerWriteRepository.Remove(customer);
				await unitOfWork.CustomerWriteRepository.SaveChangesAsync();
				return new() { Success = true };
			}
			return new() { Success = false };
		}
	}
}
