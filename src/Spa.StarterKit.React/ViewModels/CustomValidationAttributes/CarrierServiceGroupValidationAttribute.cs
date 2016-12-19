using System;
using System.ComponentModel.DataAnnotations;

namespace Spa.StarterKit.React.ViewModels.CustomValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class CarrierServiceGroupValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
        //    var model = value as CarrierServiceGroupViewModel;
        //    if (model == null) return false;

        //    if (model.GetSelectedCarrierServices().Count <= 0)
        //    {
        //        ErrorMessage = "Please select at least one carrier service.";
        //        return false;
        //    }

            return true;
        }
    }
}