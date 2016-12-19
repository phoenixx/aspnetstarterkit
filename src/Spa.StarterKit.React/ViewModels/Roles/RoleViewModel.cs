using System;
using System.Collections.Generic;
using Spa.StarterKit.React.ViewModels.CustomValidationAttributes;
using Spa.StarterKit.React.ViewModels.Shared.RolesAndPermissions;

namespace Spa.StarterKit.React.ViewModels.Roles
{
    [Serializable]
    [RoleValidation]
    public class RoleViewModel : PermissionSelectionByGroupsModel
    {
        public Guid Reference { get; set; }
        public bool Editable { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<PermissionViewModel> Permissions { get; set; }
        public Guid CustomerReference { get; set; }
    }
}