using System;

namespace Spa.StarterKit.React.ViewModels.Roles
{
    public class ViewRoleViewModel
    {
        public bool CanEdit { get; set; }

        public Guid Ref { get; set; }

        public RoleViewModel RoleData { get; set; }
    }
}