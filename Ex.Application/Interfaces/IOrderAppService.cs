using Ex.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.Interfaces
{
    public interface IOrderAppService : IDisposable
    {
        Task<ValidationResult> Add(CreateOrderModel createOrderModel);
        Task<IEnumerable<OrderViewModel>> GetOrders();
        Task<OrderViewModel> GetOrder(Guid id);
        Task<ValidationResult> UpdateOrderItem(OrderLineUpdateModel orderLineUpdate);
        Task<ValidationResult> DeleteOrderItem(DeleteOrderLineModel deleteOrderLineModel);
    }
}
