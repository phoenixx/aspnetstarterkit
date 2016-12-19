using System.Collections.Generic;
using System.Runtime.Serialization;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;

namespace Spa.StarterKit.React.ViewModels.Reports
{
    public class AuditMessageListViewModel
    {
        public const int DefaultPageSize = 10;
        [DataMember]
        public int PageSize => DefaultPageSize;

        public IEnumerable<AuditMessage> Records { get; set; }
        public int TotalRecords { get; set; }
    }
}