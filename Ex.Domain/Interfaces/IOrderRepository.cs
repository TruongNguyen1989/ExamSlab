using Ex.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ex.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Add(Order order);
        Task<List<Order>> GetOrders();
        Task<Order> GetById(Guid id);
        Task<List<Order>> GetOrderByTenantId(Guid tenantId);
    }
}
