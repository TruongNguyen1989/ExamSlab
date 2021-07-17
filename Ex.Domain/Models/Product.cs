using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Models
{
    public class Product : Entity, IAggregateRoot
    {
        public Product(Guid id,string code, string title,string description,double price, Guid tenantId)
        {
            Id = id;
            Title = title;
            TenantId = tenantId;
            Code = code;
            Description = description;
            Price = price;
        }
        protected Product() { }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
