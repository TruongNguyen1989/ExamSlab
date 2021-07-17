using Ex.Domain.Models;
using NetDevPack.Data;

namespace Ex.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Add(Customer customer);
    }
}
