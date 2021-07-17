using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class ProductEventHander :
        INotificationHandler<ProductCreateEvent>,
        INotificationHandler<ProductUpdateEvent>
    {
        public Task Handle(ProductUpdateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task Handle(ProductCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
