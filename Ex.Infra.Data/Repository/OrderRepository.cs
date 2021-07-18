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
        protected readonly DbSet<OrderLine> DbSet1;
        public OrderRepository(AppliactionContext appContext)
        {
            Db = appContext;
            DbSet = Db.Set<Order>();
            DbSet1 = Db.Set<OrderLine>();
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

        public void UpdateOrderItem(OrderLine orderLine)
        {
            Db.Entry(orderLine).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public async Task<Order> OrderLineById(Guid id)
        {
            return await DbSet.AsNoTracking().Include(x => x.OrderLines.Where(t => t.Id == id)).FirstOrDefaultAsync();
        }

        public void DeleteOrderItem(OrderLine orderLine)
        {
            Db.Entry(orderLine).State = EntityState.Deleted;
            Db.SaveChanges();
        }
    }
}
