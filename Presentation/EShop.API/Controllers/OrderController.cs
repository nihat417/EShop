using EShop.Application.Features.Commands.Orders.AddOrders;
using EShop.Application.Features.Commands.Orders.DeleteOrdes;
using EShop.Application.Features.Commands.Orders.UpdateOrders;
using EShop.Application.Features.Queries.Orders.GetAllOrders;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace EShop.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderController : ControllerBase
	{
		private readonly IMediator mediator;

		public OrderController(IMediator mediator)
		{
			this.mediator = mediator;
		}

		[HttpGet("GetAllOrders")]
		public async Task<IActionResult> GetAll([FromQuery]GetAllOrdersQueryRequest request) 
		{
			try
			{
				var response = await mediator!.Send(request);
				return Ok(response);
			}
			catch (Exception) { return StatusCode((int)HttpStatusCode.InternalServerError); }
		}

		[HttpPost("AddOrders")]
		public async Task<IActionResult> AddOrders([FromBody]AddOrdersRequest request)
		{
			try
			{
				if(ModelState.IsValid)
				{
					await mediator.Send(request);
					return StatusCode((int)HttpStatusCode.Created);
				}
				return BadRequest();
			}
			catch (Exception)
			{
				// logging
				return StatusCode((int)HttpStatusCode.InternalServerError);
			}
		}

		[HttpDelete("DeleteOrders")]
		public async Task<IActionResult>Delete(DeleteOrdersRequest request)
		{
			try
			{
				var res = await mediator.Send(request);
				return Ok(res);
			}
			catch (Exception) { return StatusCode((int)HttpStatusCode.InternalServerError); }
		}

		[HttpPut("UpdateOrder")]
		public async Task<IActionResult>Update(UpdateOrdersRequest request)
		{
			try
			{
				if(ModelState.IsValid)
				{
					var response = await mediator!.Send(request);
					return Ok(response);
				}
				return BadRequest();
			}
			catch (Exception) { return StatusCode((int)HttpStatusCode.InternalServerError); }
		}
	}
}
