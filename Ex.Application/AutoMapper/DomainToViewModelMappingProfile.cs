using AutoMapper;
using Ex.Application.ViewModels;
using Ex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Tenant, TenantViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Order, OrderViewModel>();
        }
    }
}
