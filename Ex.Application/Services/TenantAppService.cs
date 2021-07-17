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
using System.Threading.Tasks;

namespace Ex.Application.Services
{
    public class TenantAppService : ITenantAppService
    {
        private readonly IMapper _mapper;
        private readonly ITenantRepository _tenantRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;
        public TenantAppService(IMapper mapper,
                                  ITenantRepository tenantRepository,
                                  IMediatorHandler mediator,
                                  IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _tenantRepository = tenantRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }
        public async Task<ValidationResult> Add(TenantCreateModel tenantCreateModel)
        {
            var registerCommand = _mapper.Map<RegisterNewTenantCommand>(tenantCreateModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<TenantViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TenantViewModel>>(await _tenantRepository.GetAll());
        }
    }
}
