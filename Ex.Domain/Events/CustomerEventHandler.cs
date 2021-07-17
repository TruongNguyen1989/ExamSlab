using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ex.Domain.Events
{
    public class CustomerEventHandler : INotificationHandler<CustomerCreateEvent>
    {
        public Task Handle(CustomerCreateEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
