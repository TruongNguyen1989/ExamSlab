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
    public class ProductAppService : IProductAppService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;
        public ProductAppService(IMapper mapper, IProductRepository productRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _mediator = mediator;
            _eventStoreRepository = eventStoreRepository;
        }
        public async Task<ValidationResult> Add(ProductCreateModel prodcutCreateModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProductCommand>(prodcutCreateModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public async Task<ValidationResult> Update(ProductUpdateModel productUpdateModel)
        {
            var registerCommand = _mapper.Map<UpdateProductCommand>(productUpdateModel);
            return await _mediator.SendCommand(registerCommand);
        }
    }
}
