using EShop.Application.Repositories;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Features.Commands.Customers.AddCustomer
{
	public class AddCustomersCommandHandler : IRequestHandler<AddCustomersCommandRequest, AddCustomersCommandResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public AddCustomersCommandHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<AddCustomersCommandResponse> Handle(AddCustomersCommandRequest request, CancellationToken cancellationToken)
		{
			var customers = new Customer { Id=Guid.NewGuid() ,Name = request.CustomerName, CreatedTime =DateTime.Now };
			await unitOfWork.CustomerWriteRepository.AddAsync(customers);
			await unitOfWork.CustomerWriteRepository.SaveChangesAsync();
			return new();
		}
	}
}
