using EShop.Application.Repositories;
using MediatR;

namespace EShop.Application.Features.Commands.Products.DeleteProduct
{
	public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
	{
		private readonly IUnitOfWork unitOfWork;

		public DeleteProductHandler(IUnitOfWork unitOfWork)
		{
			this.unitOfWork = unitOfWork;
		}

		public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
		{
			var products = await unitOfWork.ProductReadRepository.GetAsync(request.Id);
			if(products != null)
			{
				unitOfWork.ProductWriteRepository.Remove(products);
				await unitOfWork.ProductWriteRepository.SaveChangesAsync();
				return new() { Success = true };
			}

			return new() { Success = false };
		}
	}
}
