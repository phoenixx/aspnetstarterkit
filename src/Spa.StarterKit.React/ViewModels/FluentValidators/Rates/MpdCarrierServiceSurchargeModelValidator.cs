using FluentValidation;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Rates
{
    public class MpdCarrierServiceSurchargeModelValidator : AbstractValidator<MpdCarrierServiceSurchargeModelViewModel>
    {
        public MpdCarrierServiceSurchargeModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("Surcharge Model Id is required");
        }
    }
}