using Ex.Application.Interfaces;
using Ex.Application.Services;
using Ex.Domain.Commands;
using Ex.Domain.Core.Events;
using Ex.Domain.Events;
using Ex.Domain.Interfaces;
using Ex.Infra.CrossCutting.Bus;
using Ex.Infra.Data.Context;
using Ex.Infra.Data.EventSourcing;
using Ex.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ITenantAppService, TenantAppService>();
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IProductAppService, ProductAppService>();
            // Domain - Events
            services.AddScoped<INotificationHandler<TenantCreateEvent>, TenantEventHandler>();
            services.AddScoped<INotificationHandler<CustomerCreateEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<ProductCreateEvent>, ProductEventHander>();
            services.AddScoped<INotificationHandler<ProductUpdateEvent>, ProductEventHander>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewTenantCommand, ValidationResult>,TenantCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RegisterNewProductCommand, ValidationResult>,ProductCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProductCommand, ValidationResult>, ProductCommandHandler>();

            // Infra - Data
            services.AddScoped<AppliactionContext>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
