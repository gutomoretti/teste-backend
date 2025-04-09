using Ambev.DeveloperEvaluation.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity
    {
        public required string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
