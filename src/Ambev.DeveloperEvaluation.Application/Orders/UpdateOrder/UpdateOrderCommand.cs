using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Orders.UpdateOrder
{
    public class UpdateOrderCommand : IRequest<UpdateOrderResult>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<UpdateOrderItemDto> Items { get; set; } = new();
    }

    public class UpdateOrderItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
