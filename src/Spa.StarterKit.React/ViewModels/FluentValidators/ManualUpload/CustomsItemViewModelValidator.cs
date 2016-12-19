using FluentValidation;
using Spa.StarterKit.React.ViewModels.Allocation.ManualUpload;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload
{
    public class CustomsItemViewModelValidator : AbstractValidator<CustomsItemViewModel>
    {
        public CustomsItemViewModelValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a description");
            RuleFor(x => x.CountryRef).NotEmpty().WithMessage("Please choose a country of origin");
            RuleFor(x => x.HarmonizationCode).NotEmpty().WithMessage("Please enter a harmonization code");
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("Please enter a value greater than 0");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Please choose a country");
            RuleFor(x => x.Weight).GreaterThan(0).WithMessage("Please enter a weight greater than 0");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Please enter a quantity greater than 0");
        }
    }
}