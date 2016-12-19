using System.Collections.Generic;
using System.Linq;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Reconciliation;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Spa.StarterKit.React.ViewModels.InvoiceReconciliation
{
    public class DiscrepancyViewModel
    {
        public int Id { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DiscrepancyType DiscrepancyType { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ResolutionReason Resolution { get; set; }

        public string ResolutionInformation { get; set; }

        public decimal? ActualCost => Lines.Sum(x => x.ActualCost);

        public decimal? ExpectedCost { get; set; }

        public string MpdConsignmentReference { get; set; }

        public bool Accepted { get; set; }

        public List<DiscrepancyLineViewModel> Lines { get; set; }
    }

    public class DiscrepancyLineViewModel
    {
        public string LineNumber { get; set; }

        public decimal? ActualCost { get; set; }

        public string[] OriginalInvoiceLine { get; set; }

        public string[] OriginalInvoiceLineFiltered { get; set; }

        public string[] HeaderLine { get; set; }
    }
}