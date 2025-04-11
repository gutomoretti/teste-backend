using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Orders.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<DeleteOrderResult>
    {
        public Guid Id { get; set; }
    }
}
