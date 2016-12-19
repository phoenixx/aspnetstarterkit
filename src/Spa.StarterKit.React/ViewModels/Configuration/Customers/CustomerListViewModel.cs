using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Spa.StarterKit.React.ViewModels.Configuration.Customers
{
    public class CustomerListViewModel
    {
        public const int DefaultPageSize = 25;

        [DataMember]
        public int PageSize => DefaultPageSize;

        public IEnumerable<MPD.Electio.SDK.NetCore.Internal.DataTypes.Accounts.Customer> Customers { get; set; }
        public int TotalRecords { get; set; }
    }
}