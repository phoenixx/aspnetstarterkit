using System;
using System.Collections.Generic;
using System.Linq;
using MPD.Electio.SDK.NetCore.DataTypes.Security.v1_1;

namespace Spa.StarterKit.React.ViewModels.Shared.RolesAndPermissions
{
    [Serializable]
    public abstract class PermissionSelectionByGroupsModel
    {
        public IList<PermissionGroupViewModel> Groups { get; set; }

        public void SetSelectedPermissions(IList<Permission> permissions)
        {
            foreach (var permission in permissions)
            {
                SelectPermission(permission);
            }
        }

        public virtual IList<PermissionViewModel> GetSelectedPermissions()
        {
            return Groups.SelectMany(g => g.Permissions)
                         .Where(p => p.Selected)
                         .ToList();
        }

        private void SelectPermission(Permission permissionToSelect)
        {
            var permission = Groups.SelectMany(g => g.Permissions)
                                   .SingleOrDefault(p => p.Key == permissionToSelect.Key);

            if (permission != null)
            {
                permission.Selected = true;
            }
        }
    }
}