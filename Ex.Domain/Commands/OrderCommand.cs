using Ex.Domain.Models;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class OrderCommand : Command
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public float Number { get; set; }
        public Guid TenantId { get; set; }
        public double Sum { get; set; }
        public List<OrderLine> OrderLines { get; set; }
    }
}
