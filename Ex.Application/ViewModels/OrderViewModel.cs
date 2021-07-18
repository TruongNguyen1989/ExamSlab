using Ex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.ViewModels
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float Number { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
        public double Sum { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
