using EShop.Application.Paginations;
using EShop.Application.Repositories;
using EShop.Application.Repositories.ProductRepository;
using EShop.Application.ViewModels;
using EShop.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
		private readonly IUnitOfWork _unitOfWork;

		public ProductsController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

        [HttpGet("getall")]
        public IActionResult GetAll([FromQuery] Pagination pagination)
        {
            try
            {
                var products = _unitOfWork.ProductReadRepository.GetAll(tracking: false);
                var totalCount = products.Count();

                products = products.OrderBy(p => p.CreatedTime).Skip(pagination.Size * pagination.Page).Take(pagination.Size).ToList();

                return Ok(new { products, totalCount });
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddProductViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Product product = new()
                    {
                        Id = Guid.NewGuid(),
                        Name = model.Name,
                        Description = model.Desc,
                        Price = model.Price,
                        Stock = model.Stock,
                        CreatedTime = DateTime.Now,
                    };

                    var result = await _unitOfWork.ProductWriteRepository.AddAsync(product);
                    if (result)
                    {
                        await _unitOfWork.ProductWriteRepository.SaveChangesAsync();
                        return StatusCode((int)HttpStatusCode.Created);
                    }
                }
                return BadRequest(ModelState);
            }
            catch (Exception)
            {
                // logging
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove(Guid id)
        {
            try
            {
                var product = await _unitOfWork.ProductReadRepository.GetAsync(id.ToString());
                if(product != null)
                {
                    var result = _unitOfWork.ProductWriteRepository.Remove(product);
                    if(result)
                    {
                        await _unitOfWork.ProductWriteRepository.SaveChangesAsync();
                        return Ok();
                    }

				}
                return NotFound();
			}
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(Guid id, AddProductViewModel vm)
        {
            try
            {
                if(ModelState.IsValid)
                {
					var product = await _unitOfWork.ProductReadRepository.GetAsync(id.ToString());
					if (product != null)
					{

						product.Name = vm.Name;
						product.Description = vm.Desc;
						product.Price = vm.Price;
						product.Stock = vm.Stock;

						var result = _unitOfWork.ProductWriteRepository.Update(product);
						if (result)
						{
							await _unitOfWork.ProductWriteRepository.SaveChangesAsync();
							return Ok();
						}
					}
					return NotFound();
				}
                return BadRequest(ModelState);
			}
            catch (Exception ex) { return BadRequest(ex); }
        }
        
    }
}
