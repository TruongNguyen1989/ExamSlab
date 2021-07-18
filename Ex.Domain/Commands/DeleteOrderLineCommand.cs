using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class DeleteOrderLineCommand : OrderLineCommand
    {
        public DeleteOrderLineCommand(Guid id)
        {
            Id = id;
        }
    }
}
