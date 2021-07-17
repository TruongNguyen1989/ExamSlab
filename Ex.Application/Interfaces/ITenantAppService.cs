using Ex.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.Interfaces
{
    public interface ITenantAppService : IDisposable
    {
        Task<IEnumerable<TenantViewModel>> GetAll();

        Task<ValidationResult> Add(TenantCreateModel tenantViewModel);
    }
}
