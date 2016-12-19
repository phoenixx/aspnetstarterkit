using System;
using System.ComponentModel.DataAnnotations;
using Spa.StarterKit.React.ViewModels.Roles;

namespace Spa.StarterKit.React.ViewModels.CustomValidationAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public sealed class RoleValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = value as RoleViewModel;
            if (model == null) return false;

            if (model.GetSelectedPermissions().Count <= 0)
            {
                ErrorMessage = "Please select at least one permission.";
                return false;
            }

            if (!string.IsNullOrEmpty(model.Description) && model.Description.Length > 100)
            {
                ErrorMessage = "The role description cannot be more than 100 characters.";
                return false;
            }

            if (!string.IsNullOrEmpty(model.Name) && model.Name.Length > 100)
            {
                ErrorMessage = "The role name cannot be more than 100 characters.";
                return false;
            }

            return true;
        }
    }
}