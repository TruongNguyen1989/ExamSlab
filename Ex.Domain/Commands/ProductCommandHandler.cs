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
    public class ProductCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewProductCommand, ValidationResult>,
        IRequestHandler<UpdateProductCommand, ValidationResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly ITenantRepository _tenantRepository;
        public ProductCommandHandler(IProductRepository productRepository, ITenantRepository tenantRepository)
        {
            _productRepository = productRepository;
            _tenantRepository = tenantRepository;
        }
        public async Task<ValidationResult> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var producUpdate = _productRepository.GetById(request.Id).Result;
            if (producUpdate == null)
            {
                AddError("The Prodcut does not exist.");
                return ValidationResult;
            }
            var product = new Product(request.Id, producUpdate.Code, request.Title, producUpdate.Description, producUpdate.Price, producUpdate.TenantId);

            product.AddDomainEvent(new ProductUpdateEvent(product.Id, product.Title));

            _productRepository.Update(product);

            return await Commit(_productRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RegisterNewProductCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid()) return request.ValidationResult;
            var existingtenant = await _tenantRepository.GetById(request.TenantId);

            if (existingtenant == null)
            {
                    AddError("The Tenant does not exist.");
                    return ValidationResult;
            }
            var product = new Product(Guid.NewGuid(), GenerateProductCode(request.TenantId), request.Title,request.Description,request.Price, request.TenantId);

            product.AddDomainEvent(new ProductCreateEvent(product.Id,product.Code, product.Title,product.Description,product.Price, product.TenantId));

            _productRepository.Add(product);

            return await Commit(_productRepository.UnitOfWork);
        }
        private string GenerateProductCode(Guid tendantId)
        {
            var product = _productRepository.GetByTenantId(tendantId).Result;
            Random r = new Random();
            int num = r.Next();
            string date = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            return product.Count() <= 0 ? "01" : product.Count().ToString() + num.ToString() + date + month;
        }
    }
}
