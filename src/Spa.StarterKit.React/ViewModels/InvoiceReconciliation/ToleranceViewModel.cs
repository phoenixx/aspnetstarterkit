using FluentValidation.Attributes;
using Spa.StarterKit.React.ViewModels.FluentValidators.Reconciliation;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    [Validator(typeof(ToleranceValidator))]
    public class ToleranceViewModel
    {
        public ToleranceViewModel()
        {
            Defaults = new ToleranceDefaults();
        }

        public decimal MaxPercentageDifferenceAllowed { get; set; }
        public bool MaxPercentageDifferenceAllowedIsSet { get; set; }
        public decimal ValueOfDifferenceThreshold { get; set; }
        public bool ValueOfDifferenceThresholdIsSet { get; set; }
        public decimal NegativeMaxPercentageDifferenceAllowed { get; set; }
        public bool NegativeMaxPercentageDifferenceAllowedIsSet { get; set; }
        public decimal NegativeValueOfDifferenceThreshold { get; set; }
        public bool NegativeValueOfDifferenceThresholdIsSet { get; set; }
        public int ExpectedDateRangeInDays { get; set; }
        public bool ExpectedDateRangeInDaysIsSet { get; set; }
        public ToleranceDefaults Defaults { get; set; }
    }

    public class ToleranceDefaults
    {
        public int ExpectedDateRangeInDays { get; set; }
        public decimal MaxPercentageDifferenceAllowed { get; set; }
        public decimal NegativeMaxPercentageDifferenceAllowed { get; set; }
        public decimal NegativeValueOfDifferenceThreshold { get; set; }
        public decimal ValueOfDifferenceThreshold { get; set; }
    }
}