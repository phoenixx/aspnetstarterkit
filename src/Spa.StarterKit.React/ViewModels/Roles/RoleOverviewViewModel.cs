using System;
using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Security.v1_1;
using Spa.StarterKit.React.Models;

namespace Spa.StarterKit.React.ViewModels.Roles
{
    public class RoleOverviewViewModel : SortableModel
    {
        public Guid CompanyReference { get; set; }
        public IList<Role> Roles { get; set; }
    }
}