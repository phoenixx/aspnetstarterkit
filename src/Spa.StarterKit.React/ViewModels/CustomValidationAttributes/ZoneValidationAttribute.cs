using System;
using System.ComponentModel.DataAnnotations;
using Spa.StarterKit.React.ViewModels.Configuration.Zones;

namespace Spa.StarterKit.React.ViewModels.CustomValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class ZoneValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = value as ZoneViewModel;
            if (model == null) return false;


            return true;
        }
    }
}