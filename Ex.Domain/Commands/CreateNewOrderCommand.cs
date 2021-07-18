using Ex.Domain.Commands.Validations;
using Ex.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex.Domain.Commands
{
    public class CreateNewOrderCommand : OrderCommand
    {
        public CreateNewOrderCommand(Guid customerId, Guid tenantId,List<CreateOrderLine> orderLines)
        {
            CustomerId = customerId;
            TenantId = tenantId;
            OrderLines = orderLines;
        }
        public override bool IsValid()
        {
            ValidationResult = new CreateNewOrderCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
