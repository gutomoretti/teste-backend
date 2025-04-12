using Ambev.DeveloperEvaluation.Application.Services;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentAssertions;
using NSubstitute;
using Ambev.DeveloperEvaluation.Unit.Application.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application
{
    public class OrderServiceHandlerTests
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly OrderService _service;

        public OrderServiceHandlerTests()
        {
            _orderRepository = Substitute.For<IOrderRepository>();
            _productRepository = Substitute.For<IProductRepository>();
            _service = new OrderService(_orderRepository, _productRepository);
        }

        [Fact(DisplayName = "Given order with 10 items When creating Then applies 10% discount")]
        public async Task Handle_OrderWith10Items_Applies10PercentDiscount()
        {
            // Given
            var (product, order) = OrderServiceTestData.OrderWithItems(10, 100);
            _productRepository.GetByIdAsync(product.Id).Returns(product);

            // When
            var result = await _service.CreateOrderAsync(order);

            // Then
            result.Discount.Should().Be(100); // 10% of 1000
            result.Total.Should().Be(1000);
        }

        [Fact(DisplayName = "Given order over R$500 When creating Then applies 20% discount")]
        public async Task Handle_OrderOver500_Applies20PercentDiscount()
        {
            var (product, order) = OrderServiceTestData.OrderWithItems(6, 100); // total = 600
            _productRepository.GetByIdAsync(product.Id).Returns(product);

            var result = await _service.CreateOrderAsync(order);

            result.Discount.Should().Be(120); // 20% of 600
        }

        [Fact(DisplayName = "Given less than 5 items When creating order Then no discount is applied")]
        public async Task Handle_LessThanMinimumItems_NoDiscount()
        {
            var (product, order) = OrderServiceTestData.OrderWithItems(3, 100);
            _productRepository.GetByIdAsync(product.Id).Returns(product);

            var result = await _service.CreateOrderAsync(order);

            result.Discount.Should().Be(0);
            result.Total.Should().Be(300);
        }

        [Fact(DisplayName = "Given item with more than 20 units When creating Then throws exception")]
        public async Task Handle_ItemWithMoreThan20Units_ThrowsException()
        {
            var (product, order) = OrderServiceTestData.OrderWithItems(21, 50);
            _productRepository.GetByIdAsync(product.Id).Returns(product);

            var act = () => _service.CreateOrderAsync(order);

            await act.Should().ThrowAsync<Exception>()
                .WithMessage("*Cannot add more than 20 units*");
        }
    }
}
