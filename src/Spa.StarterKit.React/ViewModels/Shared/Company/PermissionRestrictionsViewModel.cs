using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.Shared.RolesAndPermissions;

namespace Spa.StarterKit.React.ViewModels.Shared.Company
{
    public class PermissionRestrictionsViewModel : PermissionSelectionByGroupsModel
    {
        public bool UseDefaultRestrictions { get; set; }

        public override IList<PermissionViewModel> GetSelectedPermissions()
        {
            if (UseDefaultRestrictions) return new List<PermissionViewModel>();

            return base.GetSelectedPermissions();
        }
    }
}