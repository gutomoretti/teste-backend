using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderHandler : IRequestHandler<UpdateOrderCommand, UpdateOrderResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IOrderService _orderService;

        public UpdateOrderHandler(IOrderRepository orderRepository, IOrderService orderService)
        {
            _orderService = orderService;
            _orderRepository = orderRepository;
        }

        public async Task<UpdateOrderResult> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var existingOrder = await _orderRepository.GetByIdAsync(request.Id);

            if (existingOrder == null)
            {
                throw new Exception("Order not found");
            }

            existingOrder.CustomerId = request.CustomerId;
            existingOrder.Items = request.Items.Select(i => new OrderItem
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity
            }).ToList();

            var updatedOrder = await _orderService.CreateOrderAsync(existingOrder);

            return new UpdateOrderResult
            {
                Id = updatedOrder.Id,
                Total = updatedOrder.Total,
                Discount = updatedOrder.Discount
            };
        }
    }
}
