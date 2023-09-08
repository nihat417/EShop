using EShop.Application.Features.Commands.Products.AddProduct;
using EShop.Application.Features.Commands.Products.DeleteProduct;
using EShop.Application.Features.Queries.Products.GetAllProducts;
using EShop.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
		private readonly IMediator mediatR;

		public ProductsController(IMediator  mediatR)
		{
			this.mediatR = mediatR;
		}

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] GetProductsQueryRequest queryRequest)
        {
			try
			{
				var response = await mediatR.Send(queryRequest);
				return Ok(response);
			}
			catch (Exception) { return StatusCode((int)HttpStatusCode.InternalServerError); }
		}

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddProductCommandRequest commandRequest)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var response = await mediatR.Send(commandRequest);
					return Ok(response);
				}
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("removeProduct")]
        public async Task<IActionResult> Remove([FromQuery]DeleteProductRequest request)
        {
            try
            {
                var response = mediatR.Send(request);
                return Ok(response);
			}
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //[HttpPost("update")]
        //public async Task<IActionResult> Update(Guid id, AddProductViewModel vm)
        //{
        //    try
        //    {
        //        if(ModelState.IsValid)
        //        {
		//			var product = await _unitOfWork.ProductReadRepository.GetAsync(id.ToString());
		//			if (product != null)
		//			{
        //
		//				product.Name = vm.Name;
		//				product.Description = vm.Desc;
		//				product.Price = vm.Price;
		//				product.Stock = vm.Stock;
        //
		//				var result = _unitOfWork.ProductWriteRepository.Update(product);
		//				if (result)
		//				{
		//					await _unitOfWork.ProductWriteRepository.SaveChangesAsync();
		//					return Ok();
		//				}
		//			}
		//			return NotFound();
		//		}
        //        return BadRequest(ModelState);
		//	}
        //    catch (Exception ex) { return BadRequest(ex); }
        //}
        
    }
}
