using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class ProductCreateEvent : Event
    {
        public ProductCreateEvent(Guid id, string code, string title, string description, double price, Guid tenantId)
        {
            Id = id;
            Title = title;
            TenantId = tenantId;
            Code = code;
            Description = description;
            Price = price;
        }
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid TenantId { get; set; }
    }
}
