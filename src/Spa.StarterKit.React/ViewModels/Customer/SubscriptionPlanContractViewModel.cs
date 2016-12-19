using System;

namespace Spa.StarterKit.React.ViewModels.Customer
{ 
    public class SubscriptionPlanContractViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        
        public Guid Reference { get; set; }
        public string ReferenceString { get; set; }


        public bool BatchPrinting { get; set; }

        public int AdditionalCarriersQuota { get; set; }

        public bool ManualEntry { get; set; }

        public bool CSVUpload { get; set; }

        public bool ApiFeed { get; set; }

        public string CurrencyCode { get; set; }


        // ??
        public bool IsPrimaryPlan { get; set; }

        public bool AllocationRulesBasic { get; set; }

        public bool AllocationRulesAdvanced { get; set; }

        public decimal RecurringCost { get; set; }

        public bool CarrierServicesDomestic { get; set; }

        public bool CarrierServicesInternational { get; set; }
        

        public bool IsCustomPlan { get; set; }

        
        public int AdditionalCarrierServicesQuota { get; set; }

        //public List<SubscriptionLabelQuotaContract> SubscriptionLabelQuotas { get; set; }

        //public List<SubscriptionCarrierServiceContract> SubscriptionCarrierServices { get; set; }

        //public List<SubscriptionMpdCarrierServiceContract> SubscriptionMpdCarrierServices { get; set; }

    }
}