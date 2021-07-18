using Ex.Domain.Models;
using NetDevPack.Data;
using System;
using System.Threading.Tasks;

namespace Ex.Domain.Interfaces
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Add(Customer customer);
        Task<Customer> GetById(Guid Id);
    }
}
