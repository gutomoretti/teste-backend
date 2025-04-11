using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
        }

        public async Task<Order> CreateOrderAsync(Order order)
        {
            decimal total = 0;
            int totalItems = 0;

            foreach (var item in order.Items)
            {
                if (item.Quantity > 20)
                    throw new Exception($"Cannot add more than 20 units of product {item.ProductId}");

                var product = await _productRepository.GetByIdAsync(item.ProductId);

                if (product == null)
                    throw new Exception("Product Not Found");

                item.UnitPrice = product.UnitPrice;

                totalItems += item.Quantity;
                total += item.UnitPrice * item.Quantity;
            }

            order.Total = total;

            if (totalItems >= 5)
            {
                if (totalItems >= 15)
                {
                    order.Discount = total * 0.10m;
                }

                if (total >= 500)
                {
                    order.Discount = total * 0.20m;
                }
            }

            await _orderRepository.AddAsync(order);
            return order;
        }
    }
}
