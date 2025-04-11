namespace Ambev.DeveloperEvaluation.WebApi.Features.Orders.UpdateOrder
{
    public class UpdateOrderRequest
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<UpdateOrderItemRequest> Items { get; set; } = new();
    }

    public class UpdateOrderItemRequest
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
