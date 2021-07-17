
using NetDevPack.Messaging;
using System;

namespace Ex.Domain.Events
{
    public class CustomerCreateEvent : Event
    {
        public CustomerCreateEvent(Guid id, string title,Guid tenantId)
        {
            Id = id;
            Title = title;
            TenantId = tenantId;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid TenantId { get; set; }
    }
}
