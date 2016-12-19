using System;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Security.v1_1;

namespace Spa.StarterKit.React.ViewModels.Shared.RolesAndPermissions
{
    [Serializable]
    public class PermissionViewModel
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public AccessActions Action { get; set; }
        public Access Access { get; set; }
        public bool Selected { get; set; }
        public string Type { get; set; }
        public bool IsEditable { get; set; }
        public string Description { get; set; }
    }
}