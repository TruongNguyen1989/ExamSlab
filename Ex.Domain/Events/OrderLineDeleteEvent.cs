using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class OrderLineDeleteEvent : Event
    {
        public OrderLineDeleteEvent(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
