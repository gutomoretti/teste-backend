using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetAllOrders
{
    public class GetAllOrdersResult
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public int ItemCount { get; set; }
    }
}
