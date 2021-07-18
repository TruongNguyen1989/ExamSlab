using Ex.Domain.Models;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class OrderCreateEvent : Event
    {
        public OrderCreateEvent(Guid id, Guid customerId, float number, Guid tenantId, double sum)
        {
            Id = id;
            CustomerId = customerId;
            Number = number;
            TenantId = tenantId;
            Sum = sum;
            //this.OrderLines = orderLines;
        }
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public float Number { get; set; }
        public Guid TenantId { get; set; }
        public double Sum { get; set; }
        public List<CreateOrderLine> OrderLines { get; set; }
    }
}
