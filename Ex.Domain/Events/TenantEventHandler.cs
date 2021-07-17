using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class TenantEventHandler : INotificationHandler<TenantCreateEvent>
    {
        public Task Handle(TenantCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
