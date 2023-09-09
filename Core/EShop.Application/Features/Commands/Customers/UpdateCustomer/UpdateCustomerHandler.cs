using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Commands.Customers.UpdateCustomer
{
	public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerRequest, UpdateCustomerResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public UpdateCustomerHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<UpdateCustomerResponse> Handle(UpdateCustomerRequest request, CancellationToken cancellationToken)
		{
			var customers = await unitOfWork.CustomerReadRepository.GetAsync(request.CustomerId);
			if (customers != null)
			{
				customers.Name = request.CustomerName;
				unitOfWork.CustomerWriteRepository.Update(customers);
				await unitOfWork.CustomerWriteRepository.SaveChangesAsync();
				return new() { Succses = true };
			}
			return new() { Succses = false };
		}
	}
}
