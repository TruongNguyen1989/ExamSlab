using Ex.Domain.Interfaces;
using Ex.Domain.Models;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Infra.Data.Repository
{
    public class TenantRepository : ITenantRepository
    {
        protected readonly Ex.Infra.Data.Context.AppliactionContext Db;
        protected readonly DbSet<Tenant> DbSet;
        public TenantRepository(Ex.Infra.Data.Context.AppliactionContext appContext)
        {
            Db = appContext;
            DbSet = Db.Set<Tenant>();
        }
        public IUnitOfWork UnitOfWork => Db;

        public void Add(Tenant tenant)
        {
            DbSet.Add(tenant);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public async Task<IEnumerable<Tenant>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Tenant> GetById(Guid Id)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<Tenant> GetByTitle(string title)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Title == title);
        }
    }
}
