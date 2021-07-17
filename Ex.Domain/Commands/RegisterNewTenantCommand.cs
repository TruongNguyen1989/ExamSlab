using Ex.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class RegisterNewTenantCommand :  TenantCommand
    {
        public RegisterNewTenantCommand(string title)
        {
            Title = title;
        }
        public override bool IsValid()
        {
            ValidationResult = new RegisterNewTenantCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
