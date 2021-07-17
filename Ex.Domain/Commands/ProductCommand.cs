using NetDevPack.Messaging;
using System;

namespace Ex.Domain.Commands
{
    public class ProductCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Guid TenantId { get; set; }
    }
}
