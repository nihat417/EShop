using EShop.Application.Features.Commands.Customers.AddCustomer;
using EShop.Application.Features.Commands.Customers.DeleteCustomer;
using EShop.Application.Features.Commands.Customers.UpdateCustomer;
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

		[HttpGet("GetAllCustomers")]
		public IActionResult GetAll([FromQuery] GetCustomersQueryRequest request) 
		{
			try
			{
				var response = mediator.Send(request);
				return Ok(response);
			}
			catch (Exception) { return new NotFoundResult(); }
		}

		[HttpPost("AddCustomers")]
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

		[HttpDelete("DeleteCustomer")]
		public async Task<IActionResult> Remove([FromQuery] DeleteCustomerRequest Request)
		{
			try
			{
				if(ModelState.IsValid)
				{
					var response = await mediator.Send(Request);
					return Ok(response);
				}
				return BadRequest();
			}
			catch (Exception) { return new NotFoundResult(); };
		}

		[HttpPut("UpdateCustomer")]
		public async Task<IActionResult> Update([FromBody] UpdateCustomerRequest request)
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
			catch (Exception) { return new NotFoundResult();}
		}
	}
}
