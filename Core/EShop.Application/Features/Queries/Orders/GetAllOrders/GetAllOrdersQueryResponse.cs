namespace EShop.Application.Features.Queries.Orders.GetAllOrders
{
	public class GetAllOrdersQueryResponse
	{
		public int TotalCount { get; set; }
		public object? Orders { get; set; }
	}
}
