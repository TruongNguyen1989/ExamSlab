using FluentValidation;
using System;

namespace Ex.Domain.Commands.Validations
{
    public class ProductValidation<T> : AbstractValidator<T> where T : ProductCommand
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
        protected void ValidateCode()
        {
            RuleFor(c => c.Code)
                .NotEqual(string.Empty);
        }
        protected void ValidatePrice()
        {
            RuleFor(c => c.Price)
                .NotEmpty().WithMessage("Please ensure you have entered the Price").GreaterThan(0)
                .WithMessage("Price must be greater than 0");
        }
        protected void ValidateTenantId()
        {
            RuleFor(c => c.TenantId)
                .NotEqual(Guid.Empty);
        }
    }
}
