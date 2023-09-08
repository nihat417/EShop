using EShop.Application.Repositories;
using EShop.Domain.Entities;
using MediatR;

namespace EShop.Application.Features.Commands.Products.AddProduct
{
	public class AddProductCommandHandler : IRequestHandler<AddProductCommandRequest, AddProductCommandResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public AddProductCommandHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<AddProductCommandResponse> Handle(AddProductCommandRequest request, CancellationToken cancellationToken)
		{
			var product = new Product
			{
				Id = Guid.NewGuid(),
				Name = request.ProductName,
				Description = request.ProductDescription,
				Price = request.Price,
				Stock = request.Stock,
				CreatedTime = DateTime.Now,
			};
			await unitOfWork.ProductWriteRepository.AddAsync(product);
			await unitOfWork.ProductWriteRepository.SaveChangesAsync();
			return new();
		}
	}
}
