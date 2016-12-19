using System;
using System.ComponentModel.DataAnnotations;
using Spa.StarterKit.React.ViewModels.Profile;

namespace Spa.StarterKit.React.ViewModels.CustomValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class CompensationAndValueValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = value as CompensationAndValueViewModel;
            if (model == null) return false;

            if (model.GetEnhancedCompensation)
            {
                if (model.CompensationThreshold.HasValue == false)
                {
                    ErrorMessage = "Please specify difference between parcel value and base compensation value.";
                    return false;
                }
                if (model.CompensationThreshold.Value < 0)
                {
                    ErrorMessage = "Difference between parcel value and base compensation value cannot be a negative number.";
                    return false;
                }
            }

            return true;
        }
    }
}