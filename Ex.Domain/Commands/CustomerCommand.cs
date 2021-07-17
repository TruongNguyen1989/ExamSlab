using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class CustomerCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Title { get; protected set; }
        public Guid TenantId { get; protected set; }
    }
}
