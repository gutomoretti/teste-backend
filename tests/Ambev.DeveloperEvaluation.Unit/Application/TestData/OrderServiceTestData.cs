using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
    public class OrderServiceTestData
    {
        public static (Product, Order) OrderWithItems(int quantity, decimal unitPrice)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = "Test Product",
                UnitPrice = unitPrice
            };

            var item = new OrderItem
            {
                ProductId = product.Id,
                Quantity = quantity
            };

            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                Items = new List<OrderItem> { item }
            };

            return (product, order);
        }
    }
}
