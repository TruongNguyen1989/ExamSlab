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
    public class OrderRepository : IOrderRepository
    {

        protected readonly AppliactionContext Db;
        protected readonly DbSet<Order> DbSet;
        public OrderRepository(AppliactionContext appContext)
        {
            Db = appContext;
            DbSet = Db.Set<Order>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Order order)
        {
            DbSet.Add(order);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<List<Order>> GetOrders()
        {
            return await DbSet.Include(x=>x.OrderLines).AsNoTracking().ToListAsync();
        }

        public async Task<Order> GetById(Guid id)
        {
            return await DbSet.Include(x=>x.OrderLines).AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<List<Order>> GetOrderByTenantId(Guid tenantId)
        {
            return await DbSet.AsNoTracking().Where(c => c.TenantId == tenantId).ToListAsync();
        }
    }
}
