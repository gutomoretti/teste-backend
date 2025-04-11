using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetAllOrders
{
    public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersCommand, List<GetAllOrdersResult>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetAllOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<GetAllOrdersResult>> Handle(GetAllOrdersCommand request, CancellationToken cancellationToken)
        {
            var orders = await _orderRepository.GetAllAsync();

            return orders.Select(order => new GetAllOrdersResult
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                Total = order.Total,
                Discount = order.Discount,
                ItemCount = order.Items.Count
            }).ToList();
        }
    }
}
