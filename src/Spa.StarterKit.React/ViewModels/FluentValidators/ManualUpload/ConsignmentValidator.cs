using FluentValidation;
using Spa.StarterKit.React.ViewModels.Allocation;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload
{
    public class ConsignmentValidator : AbstractValidator<ConsignmentViewModel>
    {
        public ConsignmentValidator()
        {
            RuleFor(x => x.DestinationAddress).SetValidator(new ConsignmentAddressValidator());
            RuleFor(x => x.OriginAddress).SetValidator(new ConsignmentAddressValidator());

            RuleFor(x => x.DestinationAddress.ShippingLocationReference)
                .NotEmpty()
                .When(x => string.IsNullOrEmpty(x.OriginAddress.ShippingLocationReference))
                .WithMessage("At least one end of the journey must include a Shipping Location reference");

            RuleFor(x => x.OriginAddress.ShippingLocationReference)
                .NotEmpty()
                .When(x => string.IsNullOrEmpty(x.DestinationAddress.ShippingLocationReference))
                .WithMessage("At least one end of the journey must include a Shipping Location reference");
        }
    }
}