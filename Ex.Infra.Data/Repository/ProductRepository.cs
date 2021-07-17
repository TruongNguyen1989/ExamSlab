using Ex.Domain.Interfaces;
using Ex.Domain.Models;
using Ex.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        protected readonly AppliactionContext Db;
        protected readonly DbSet<Product> DbSet;
        public ProductRepository(AppliactionContext appContext)
        {
            Db = appContext;
            DbSet = Db.Set<Product>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Product product)
        {
            DbSet.Add(product);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<Product> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<Product>> GetByTenantId(Guid tenantId)
        {
            return await DbSet.AsNoTracking().Where(c => c.TenantId == tenantId).ToListAsync();
        }

        public void Update(Product product)
        {
            DbSet.Update(product);
        }
    }
}
