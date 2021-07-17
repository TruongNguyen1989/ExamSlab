namespace Ex.Domain.Commands.Validations
{
    public class RegisterNewCustomerCommandValidation : CustomerValidation<RegisterNewCustomerCommand>
    {
        public RegisterNewCustomerCommandValidation()
        {
            ValidateTenantId();
            ValidateTitle();
        }
    }
}
