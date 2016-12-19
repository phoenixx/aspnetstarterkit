using System;
using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Subscriptions;

namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
	public class AddSubscriptionPlanViewModel
	{
        public int? Id { get; set; }

        public Guid Reference { get; set; }

        public string ReferenceString { get; set; }

        public string Name { get; set; }

        public bool BatchPrinting { get; set; }

        public int AdditionalCarriersQuota { get; set; }

        public bool ManualEntry { get; set; }

        public bool CSVUpload { get; set; }

        public bool ApiFeed { get; set; }

        public string CurrencyCode { get; set; }

        public bool IsPrimaryPlan { get; set; }

        public bool AllocationRulesBasic { get; set; }

        public bool AllocationRulesAdvanced { get; set; }

        public decimal RecurringCost { get; set; }

        public bool CarrierServicesDomestic { get; set; }

        public bool CarrierServicesInternational { get; set; }

        public bool IsPlanActive { get; set; }

        public bool IsCustomPlan { get; set; }

        public bool IsRemoved { get; set; }

        public DateTime? DateRemoved { get; set; }

        public DateTime DateCreated { get; set; }

        public int AdditionalCarrierServicesQuota { get; set; }

        public bool IsCreated { get; set; }

        public int AddQuota_QuotaStart { get; set; }

        public int AddQuota_QuotaEnd { get; set; }

        public decimal AddQuota_LabelCost { get; set; }

        public List<Currency> Currencies { get; set; }

        public List<MpdCarrierService> MpdCarrierServices { get; set; }

        public List<SubscriptionLabelQuotaContract> SubscriptionLabelQuotas { get; set; }

        public List<string> MpdCarrierServicesSelected { get; set; }

        public AddSubscriptionPlanViewModel()
        {
            this.MpdCarrierServicesSelected = new List<string>();
            this.SubscriptionLabelQuotas = new List<SubscriptionLabelQuotaContract>();
        }
	}
}
