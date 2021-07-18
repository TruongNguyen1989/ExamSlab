using Ex.Domain.Events;
using Ex.Domain.Interfaces;
using Ex.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class OrderLineCommandHander : CommandHandler,
        IRequestHandler<UpdateOrderLineCommand, ValidationResult>,
        IRequestHandler<DeleteOrderLineCommand, ValidationResult>
    {
        private readonly IOrderRepository _orderRepository;
        public OrderLineCommandHander(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<ValidationResult> Handle(UpdateOrderLineCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var order = _orderRepository.OrderLineById(request.Id).Result;
            var orderline = order.OrderLines.ToList();
            if (orderline.Count() <= 0 )
            {
                AddError("The order line does not exist.");
                return ValidationResult;
            }
            var _orderline = orderline.SingleOrDefault();
            var updateOrderline = new OrderLine(request.Id, _orderline.ProductId, request.Quantity, _orderline.ProductPrice, Convert.ToDouble(_orderline.ProductPrice * request.Quantity));

            order.AddDomainEvent(new OrderLineUpdateEvent(order.Id, updateOrderline.Quantity, updateOrderline.Cost));
            updateOrderline.OrderId = _orderline.OrderId;
            _orderRepository.UpdateOrderItem(updateOrderline);

            return await Commit(_orderRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteOrderLineCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var order = _orderRepository.OrderLineById(request.Id).Result;
            var orderline = order.OrderLines.ToList();
            if (orderline.Count() <= 0)
            {
                AddError("The order line does not exist.");
                return ValidationResult;
            }
            var _orderline = orderline.SingleOrDefault();
            var updateOrderline = new OrderLine(request.Id, _orderline.ProductId, request.Quantity, _orderline.ProductPrice, Convert.ToDouble(_orderline.ProductPrice * request.Quantity));

            order.AddDomainEvent(new OrderLineDeleteEvent(order.Id));
            updateOrderline.OrderId = _orderline.OrderId;
            _orderRepository.DeleteOrderItem(updateOrderline);

            return await Commit(_orderRepository.UnitOfWork);
        }
    }
}
