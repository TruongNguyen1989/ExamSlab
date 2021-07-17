using NetDevPack.Domain;
using System;

namespace Ex.Domain.Models
{
    public class Customer : Entity, IAggregateRoot
    {
        public Customer(Guid id, string title, Guid tenantId)
        {
            Id = id;
            Title = title;
            TenantId = tenantId;
        }
        protected Customer() { }
        public string Title { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
