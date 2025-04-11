namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.GetAllOrders
{
    public class GetAllOrdersResponse
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public int ItemCount { get; set; }
    }
}
