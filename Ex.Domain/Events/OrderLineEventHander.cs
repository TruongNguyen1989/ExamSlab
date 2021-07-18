using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class OrderLineEventHander : 
        INotificationHandler<OrderLineUpdateEvent>,
        INotificationHandler<OrderLineDeleteEvent>
    {
        public  Task Handle(OrderLineUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(OrderLineDeleteEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
