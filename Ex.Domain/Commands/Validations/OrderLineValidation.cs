using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands.Validations
{
    public class OrderLineValidation<T> : AbstractValidator<T> where T : OrderLineCommand
    {
        protected void ValidateQuantity()
        {
            RuleFor(c => c.Quantity)
                .NotEmpty().WithMessage("Please ensure you have entered the Quantity").GreaterThan(0)
                .WithMessage("Quantity must be greater than 0");
        }
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
               .NotEqual(Guid.Empty).WithMessage("Please ensure you have entered the Id");
        }
    }
}
