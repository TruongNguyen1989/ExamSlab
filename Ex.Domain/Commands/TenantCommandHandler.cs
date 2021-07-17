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
    public class TenantCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewTenantCommand, ValidationResult>
    {
        private readonly ITenantRepository _tenantRepository;
        public TenantCommandHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewTenantCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var tenant = new Tenant(Guid.NewGuid(), message.Title);

            if (await _tenantRepository.GetByTitle(tenant.Title) != null)
            {
                AddError("The tenant title has already been taken.");
                return ValidationResult;
            }

            tenant.AddDomainEvent(new TenantCreateEvent(tenant.Id, tenant.Title));

            _tenantRepository.Add(tenant);

            return await Commit(_tenantRepository.UnitOfWork);
        }
    }
}
