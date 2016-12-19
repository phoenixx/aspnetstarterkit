using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Rates
{
    public class CarrierServiceSurchargeModelValidator : AbstractValidator<CarrierServiceSurchargeModelViewModel>
    {
        public CarrierServiceSurchargeModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Surcharge Model Id is required");
        }
    }
}