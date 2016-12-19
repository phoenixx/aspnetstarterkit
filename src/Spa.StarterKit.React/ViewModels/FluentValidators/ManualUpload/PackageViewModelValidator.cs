using FluentValidation;
using Spa.StarterKit.React.ViewModels.Allocation;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload
{
    public class PackageViewModelValidator : AbstractValidator<PackageViewModel>
    {
        public PackageViewModelValidator()
        {

            RuleFor(x => x.Items)
                .SetCollectionValidator(new ItemViewModelValidator());

            RuleFor(x => x.Height)
                .NotEmpty()
                .GreaterThan(0).Unless(x => !string.IsNullOrWhiteSpace(x.PackageSizeReference))
                .WithMessage("Height is required")
                ;

            RuleFor(x => x.Width)
                .NotEmpty()
                .GreaterThan(0).Unless(x => !string.IsNullOrWhiteSpace(x.PackageSizeReference))
                .WithMessage("Width is required")
                ;

            RuleFor(x => x.Length)
                .NotEmpty()
                .GreaterThan(0).Unless(x => !string.IsNullOrWhiteSpace(x.PackageSizeReference))
                .WithMessage("Length is required")
                ;

            RuleFor(x => x.Weight)
                .NotEmpty()
                .GreaterThan(0).Unless(x => !string.IsNullOrWhiteSpace(x.PackageSizeReference))
                .WithMessage("Weight is required")
                ;

            RuleFor(x => x.Value)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("Value must be greater than 0")
                ;

            RuleFor(x => x.Description).NotEmpty().WithMessage("Please enter a package description");

        }
    }
}