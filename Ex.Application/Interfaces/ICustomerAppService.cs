using Ex.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace Ex.Application.Interfaces
{
    public interface ICustomerAppService : IDisposable
    {
        Task<ValidationResult> Add(CustomerCreateModel customerCreateModel);
    }
}
