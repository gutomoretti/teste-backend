using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Order : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
        public decimal Discount { get; set; }

        public ICollection<OrderItem> Items { get; set; }
    }
}
