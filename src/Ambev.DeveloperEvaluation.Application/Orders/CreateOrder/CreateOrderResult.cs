using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Orders.CreateOrder
{
    public class CreateOrderResult
    {
        public Guid OrderId { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
    }
}
