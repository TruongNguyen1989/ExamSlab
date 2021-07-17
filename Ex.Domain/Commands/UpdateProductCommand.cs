using Ex.Domain.Commands.Validations;

namespace Ex.Domain.Commands
{
    public class UpdateProductCommand : ProductCommand
    {
        public UpdateProductCommand(string title)
        {
            Title = title;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateProdcutCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
