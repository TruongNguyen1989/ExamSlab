using Ex.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Application.Interfaces
{
    public interface IProductAppService : IDisposable
    {
        Task<ValidationResult> Update(ProductUpdateModel productUpdateModel);
        Task<ValidationResult> Add(ProductCreateModel prodcutCreateModel);
    }
}
