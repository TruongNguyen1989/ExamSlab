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
        void UpdateOrderItem(OrderLine orderLine);
        void DeleteOrderItem(OrderLine orderLine);
        Task<List<Order>> GetOrders();
        Task<Order> GetById(Guid id);
        Task<List<Order>> GetOrderByTenantId(Guid tenantId);
        Task<Order> OrderLineById(Guid id);
    }
}
