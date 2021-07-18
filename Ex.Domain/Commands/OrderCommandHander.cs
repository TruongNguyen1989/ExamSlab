using Ex.Domain.Events;
using Ex.Domain.Interfaces;
using Ex.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class OrderCommandHander : CommandHandler,
        IRequestHandler<CreateNewOrderCommand, ValidationResult>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _prodcutRepository;
        public OrderCommandHander(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _prodcutRepository = productRepository;
        }
        public async Task<ValidationResult> Handle(CreateNewOrderCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var count = request.OrderLines.GroupBy(x => x.ProductId).Select(x => x.Key).Count();
            if (count > 1)
            {
                AddError("Prodcut Items must be unique in Order.");
                return ValidationResult;
            }
            if (request.OrderLines.Count() > 5)
            {
                AddError("Order cannot have more than 5 order lines.");
                return ValidationResult;
            }

            var order = new Order(Guid.NewGuid(), request.CustomerId, request.Number, request.TenantId, request.Sum);
            var countNumber = _orderRepository.GetOrderByTenantId(request.TenantId).Result;
            var orderitem = new List<OrderLine>();

            foreach (var item in request.OrderLines)
            {
                if (item.Quantity <= 0)
                {
                    AddError("Quantity can not be less than 1.");
                    return ValidationResult;
                }
                var product = _prodcutRepository.GetById(item.ProductId).Result;
                OrderLine ordertmp = new OrderLine();
                ordertmp.Id = Guid.NewGuid();
                ordertmp.ProductId = product.Id;
                ordertmp.Quantity = item.Quantity;
                ordertmp.ProductPrice = product.Price;
                ordertmp.Cost = Convert.ToDouble(product.Price * item.Quantity);
                orderitem.Add(ordertmp);
            }

            order.AddOrderItem(orderitem);
            order.Sum = GetSum(orderitem);
            order.Number = countNumber.Count() + 1;
            order.AddDomainEvent(new OrderCreateEvent(order.Id, order.CustomerId, order.Number, order.TenantId, order.Sum));
            _orderRepository.Add(order);

            return await Commit(_orderRepository.UnitOfWork);
        }
        public double GetSum(List<OrderLine> orderLines)
        {
            return  orderLines.Sum(o => o.Quantity * o.ProductPrice);
        }
    }
}
