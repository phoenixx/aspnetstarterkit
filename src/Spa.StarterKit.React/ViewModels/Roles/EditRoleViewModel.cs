using System;

namespace Spa.StarterKit.React.ViewModels.Roles
{
    public class EditRoleViewModel
    {
        public Guid CompanyReference { get; set; }

        public Guid Reference { get; set; }

        public RoleViewModel RoleData { get; set; } 
    }
}