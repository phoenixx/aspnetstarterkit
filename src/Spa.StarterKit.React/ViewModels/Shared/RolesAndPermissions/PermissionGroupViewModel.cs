using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Shared.RolesAndPermissions
{
    public class PermissionGroupViewModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public IList<PermissionViewModel> Permissions { get; set; }
        public bool IsEditable { get; set; }
    }
}