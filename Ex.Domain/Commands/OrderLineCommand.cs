using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class OrderLineCommand : Command
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
    }
}
