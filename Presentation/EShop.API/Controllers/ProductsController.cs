using EShop.Application.Features.Commands.Products.AddProduct;
using EShop.Application.Features.Commands.Products.DeleteProduct;
using EShop.Application.Features.Commands.Products.UpdateProduct;
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

        [HttpGet("GetallProducts")]
        public async Task<IActionResult> GetAll([FromQuery] GetProductsQueryRequest queryRequest)
        {
			try
			{
				var response = await mediatR.Send(queryRequest);
				return Ok(response);
			}
			catch (Exception) { return StatusCode((int)HttpStatusCode.InternalServerError); }
		}

        [HttpPost("AddProduct")]
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

        [HttpDelete("RemoveProduct")]
        public async Task<IActionResult> Remove([FromQuery]DeleteProductRequest request)
        {
            try
            {
                var response = await mediatR.Send(request);
                return Ok(response);
			}
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Update([FromBody]UpdateProductRequest updateProductRequest)
        {
            try
            {
                if(ModelState.IsValid)
                {
					var response = await mediatR.Send(updateProductRequest);
					return(Ok(response));
				}
                return BadRequest(ModelState);
			}
            catch (Exception ex) { return BadRequest(ex); }
        }
        
    }
}
