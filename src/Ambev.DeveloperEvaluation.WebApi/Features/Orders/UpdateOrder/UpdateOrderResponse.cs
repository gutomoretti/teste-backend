namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder
{
    public class UpdateOrderResponse
    {
        public Guid Id { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
    }
}
