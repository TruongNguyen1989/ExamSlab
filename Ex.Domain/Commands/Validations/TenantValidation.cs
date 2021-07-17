using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands.Validations
{
    public abstract class TenantValidation<T> : AbstractValidator<T> where T : TenantCommand
    {
        protected void ValidateTitle()
        {
            RuleFor(c => c.Title)
                .NotEmpty().WithMessage("Please ensure you have entered the Title")
                .Length(2, 250).WithMessage("The Name must have between 2 and 250 characters");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
    }
}
