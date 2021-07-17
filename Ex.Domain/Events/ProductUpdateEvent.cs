using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class ProductUpdateEvent : Event
    {
        public ProductUpdateEvent(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
    }
}
