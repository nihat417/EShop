using EShop.Application.Features.Commands.Customers.AddCustomer;
using EShop.Application.Features.Queries.Customers.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : ControllerBase
	{
		private readonly IMediator mediator;
		public CustomerController(IMediator mediator) 
		{
			this.mediator = mediator;
		}

		[HttpGet("getallcust")]
		public IActionResult GetAll([FromQuery] GetCustomersQueryRequest request) 
		{
			try
			{
				var response = mediator.Send(request);
				return Ok(response);
			}
			catch (Exception) { return new NotFoundResult(); }
		}

		[HttpPost("addcust")]
		public async Task<IActionResult> Add([FromBody] AddCustomersCommandRequest request)
		{
			try
			{
				if(ModelState.IsValid)
				{
					var response = await mediator.Send(request);
					return Ok(response);
				}
				return BadRequest();
			}
			catch (Exception) {return new NotFoundResult();}
		}
	}
}
