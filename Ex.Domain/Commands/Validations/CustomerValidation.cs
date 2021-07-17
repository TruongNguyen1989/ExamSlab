using FluentValidation;
using System;

namespace Ex.Domain.Commands.Validations
{
    public class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
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
        protected void ValidateTenantId()
        {
            RuleFor(c => c.TenantId)
                .NotEqual(Guid.Empty);
        }
    }
}
