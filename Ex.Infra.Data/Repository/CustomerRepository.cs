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
    public class CustomerRepository : ICustomerRepository
    {
        protected readonly AppliactionContext Db;
        protected readonly DbSet<Customer> DbSet;
        public CustomerRepository(AppliactionContext appContext)
        {
            Db = appContext;
            DbSet = Db.Set<Customer>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Customer customer)
        {
            DbSet.Add(customer);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
