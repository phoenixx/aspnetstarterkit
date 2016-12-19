using System.Collections.Generic;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Subscriptions;

namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
    public class EditSubscriptionPlanViewModel
    {
        public EditSubscriptionPlanViewModel()
        {
            this.MpdCarrierServicesSelected = new List<string>();
            this.SubscriptionLabelQuotas = new List<SubscriptionLabelQuotaContract>();
        }

        public int Id { get; set; }
        public string ReferenceString { get; set; }
        public string Name { get; set; }
        public int AdditionalCarriersQuota { get; set; }
        public string CurrencyCode { get; set; }
        public decimal RecurringCost { get; set; }
        public int AdditionalCarrierServicesQuota { get; set; }
        public bool IsPlanActive { get; set; }
        public bool IsCustomPlan { get; set; }


        public bool IsCreated { get; set; }


        public List<MpdCarrierService> MpdCarrierServices { get; set; }
        
        public List<string> MpdCarrierServicesSelected { get; set; }

        public List<SubscriptionLabelQuotaContract> SubscriptionLabelQuotas { get; set; }

    }
}