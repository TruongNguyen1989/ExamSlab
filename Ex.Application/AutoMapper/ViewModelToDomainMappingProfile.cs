using AutoMapper;
using Ex.Application.ViewModels;
using Ex.Domain.Commands;

namespace Ex.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<TenantViewModel, RegisterNewTenantCommand>()
                .ConstructUsing(c => new RegisterNewTenantCommand(c.Title));

            CreateMap<TenantCreateModel, RegisterNewTenantCommand>()
               .ConstructUsing(c => new RegisterNewTenantCommand(c.Title));

            CreateMap<CustomerCreateModel, RegisterNewCustomerCommand>()
              .ConstructUsing(c => new RegisterNewCustomerCommand(c.Title,c.TenantId));

            CreateMap<ProductCreateModel, RegisterNewProductCommand>()
             .ConstructUsing(c => new RegisterNewProductCommand(c.Title, c.Description,c.Price, c.TenantId));

            CreateMap<ProductUpdateModel, UpdateProductCommand>()
             .ConstructUsing(c => new UpdateProductCommand(c.Title));

            CreateMap<CreateOrderModel, CreateNewOrderCommand>()
            .ConstructUsing(c => new CreateNewOrderCommand(c.CustomerId,c.TenantId,c.OrderLines));

            CreateMap<OrderLineUpdateModel, UpdateOrderLineCommand>()
           .ConstructUsing(c => new UpdateOrderLineCommand(c.Quantity));

            CreateMap<DeleteOrderLineModel, DeleteOrderLineCommand>()
         .ConstructUsing(c => new DeleteOrderLineCommand(c.Id));
        }
    }
}
