using Ex.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class UpdateOrderLineCommand : OrderLineCommand
    {
        public UpdateOrderLineCommand(int quantity)
        {
            Quantity = quantity;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateOrderLineCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
