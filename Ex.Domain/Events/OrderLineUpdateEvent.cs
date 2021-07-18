using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class OrderLineUpdateEvent : Event
    {
        public OrderLineUpdateEvent(Guid id, int quantity,double cost)
        {
            Id = id;
            Quantity = quantity;
            Cost = cost;
        }
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public double Cost { get; set; }
    }
}
