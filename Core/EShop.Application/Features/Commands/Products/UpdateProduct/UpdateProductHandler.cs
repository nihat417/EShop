using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Commands.Products.UpdateProduct
{
	public class UpdateProductHandler : IRequestHandler<UpdateProductRequest, UpdateProductResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public UpdateProductHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<UpdateProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
		{
			var product = await unitOfWork.ProductReadRepository.GetAsync(request.ProductId);
			if(product != null)
			{
				product.Name = request.ProductName;
				product.Description = request.ProductDescription;
				product.Stock = request.Stock;
				product.Price = request.Price;

				unitOfWork.ProductWriteRepository.Update(product);
				await unitOfWork.ProductWriteRepository.SaveChangesAsync();
				return new() { Succses = true };
			}
			return new() { Succses = false };
		}
	}
}
