using FluentValidation;
using Spa.StarterKit.React.ViewModels.Allocation;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload
{
    public class ItemViewModelValidator : AbstractValidator<ItemViewModel>
    {
        public ItemViewModelValidator()
        {
            RuleFor(x => x.DisplayName).NotEmpty().WithMessage("Please enter a description");
            RuleFor(x => x.Length).GreaterThanOrEqualTo(1).WithMessage("Please enter 1 or greater for Length");
            RuleFor(x => x.Width).GreaterThanOrEqualTo(1).WithMessage("Please enter 1 or greater for Width");
            RuleFor(x => x.Height).GreaterThanOrEqualTo(1).WithMessage("Please enter 1 or greater for Height");
            RuleFor(x => x.Weight).GreaterThan(0).WithMessage("Please enter 0.01 or greater for Weight");
            RuleFor(x => x.Value).GreaterThan(0).WithMessage("Value must be greater than 0");
            RuleFor(x => x.CountryOfOrigin).NotEmpty().WithMessage("Please choose a country");
            RuleFor(x => x.Currency).NotEmpty().WithMessage("Please choose a currency");
            RuleFor(x => x.BarcodeType).NotNull().When(b => !string.IsNullOrEmpty(b.Barcode)).WithMessage("Please enter a barcode type");
        }
    }
}