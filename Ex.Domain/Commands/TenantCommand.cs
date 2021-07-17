using NetDevPack.Messaging;
using System;

namespace Ex.Domain.Commands
{
    public abstract class TenantCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Title { get; protected set; }
    }
}
