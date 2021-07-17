using Ex.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Interfaces
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        Task<IEnumerable<Tenant>> GetAll();
        Task<Tenant> GetByTitle(string title);
        Task<Tenant> GetById(Guid Id);
        void Add(Tenant tenant);
    }
}
