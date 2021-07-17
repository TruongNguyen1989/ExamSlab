using AutoMapper;
using Ex.Application.Interfaces;
using Ex.Application.ViewModels;
using Ex.Domain.Commands;
using Ex.Domain.Interfaces;
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
    public class CustomerAppService : ICustomerAppService
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;
        public CustomerAppService(IMapper mapper,
                                  ICustomerRepository customerRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }
        public async Task<ValidationResult> Add(CustomerCreateModel customerCreateModel)
        {
            var registerCommand = _mapper.Map<RegisterNewCustomerCommand>(customerCreateModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
