using Ex.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void Add(Product product);
        void Update(Product product);
        Task<List<Product>> GetByTenantId(Guid tenantId);
        Task<Product> GetById(Guid id);
    }
}
