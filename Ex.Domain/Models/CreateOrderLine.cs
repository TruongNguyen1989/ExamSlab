using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Models
{
    public class CreateOrderLine
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double ProductPrice { get; set; }
        public double Cost { get; set; }
    }
}
