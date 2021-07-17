using Ex.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class RegisterNewProductCommand : ProductCommand
    {
        public RegisterNewProductCommand( string title, string description, double price, Guid tenantId)
        {
            Title = title;
            TenantId = tenantId;
            Description = description;
            Price = price;           
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProductCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
