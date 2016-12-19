using FluentValidation;
using Spa.StarterKit.React.ViewModels.InvoiceReconciliation;

namespace Spa.StarterKit.React.ViewModels.FluentValidators.Reconciliation
{
    public class ToleranceValidator : AbstractValidator<ToleranceViewModel>
    {
        public ToleranceValidator()
        {
            RuleFor(x => x.ExpectedDateRangeInDays)
                .GreaterThanOrEqualTo(-1)
                .WithMessage("Expected date range in days must be -1 or greater");

            RuleFor(x => x.MaxPercentageDifferenceAllowed)
                .InclusiveBetween(0, 100)
                .WithMessage("Maximum percentage difference must be between 0 and 100");

            RuleFor(x => x.NegativeMaxPercentageDifferenceAllowed)
                .InclusiveBetween(0, 100)
                .WithMessage("Negative percentage difference must be between 0 and 100");

            RuleFor(x => x.NegativeValueOfDifferenceThreshold)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Negative value difference must be 0 or greater");

            RuleFor(x => x.ValueOfDifferenceThreshold)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Value difference must be 0 or greater");
        }
    }
}