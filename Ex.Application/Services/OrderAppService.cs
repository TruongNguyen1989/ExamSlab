using AutoMapper;
using Ex.Application.Interfaces;
using Ex.Application.ViewModels;
using Ex.Domain.Commands;
using Ex.Domain.Interfaces;
using Ex.Domain.Models;
using Ex.Infra.Data.Repository;
using FluentValidation.Results;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.Services
{
    public class OrderAppService : IOrderAppService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;
        public OrderAppService(IMapper mapper, IOrderRepository orderRepository, IEventStoreRepository  eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }
        public async Task<ValidationResult> Add(CreateOrderModel createOrderModel)
        {
            var _tm = createOrderModel.OrderLines.Select(x => new CreateOrderLine
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();

            var registerCommand = new CreateNewOrderCommand(createOrderModel.CustomerId, createOrderModel.TenantId, _tm);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<OrderViewModel>> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderViewModel>>(await _orderRepository.GetOrders());
        }
    }
}
