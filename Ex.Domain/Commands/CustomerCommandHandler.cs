using Ex.Domain.Events;
using Ex.Domain.Interfaces;
using Ex.Domain.Models;
using FluentValidation.Results;
using MediatR;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class CustomerCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCustomerCommand, ValidationResult>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ITenantRepository _tenantRepository;
        public CustomerCommandHandler(ICustomerRepository customerRepository, ITenantRepository tenantRepository)
        {
            _customerRepository = customerRepository;
            _tenantRepository = tenantRepository;
        }
        public async Task<ValidationResult> Handle(RegisterNewCustomerCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var existingtenant = await _tenantRepository.GetById(request.TenantId);

            if (existingtenant == null)
            {
                AddError("The Tenant does not exist.");
                return ValidationResult;
            }
            var customer = new Customer(Guid.NewGuid(), request.Title, request.TenantId);

            customer.AddDomainEvent(new CustomerCreateEvent(customer.Id, customer.Title,customer.TenantId));

            _customerRepository.Add(customer);

            return await Commit(_customerRepository.UnitOfWork);
        }
    }
}
