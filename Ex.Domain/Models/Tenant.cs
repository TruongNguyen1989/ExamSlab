using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Models
{
    public class Tenant : Entity, IAggregateRoot
    {
        public Tenant(Guid id, string title)
        {
            Id = id;
            Title = title;
        }
        protected Tenant() { }
        public string Title { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
