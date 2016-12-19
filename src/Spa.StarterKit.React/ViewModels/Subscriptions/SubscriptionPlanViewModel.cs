using System;
using System.Collections.Generic;

namespace Spa.StarterKit.React.ViewModels.Subscriptions
{
    public class SubscriptionPlanViewModel
    {
        public IList<LabelQuotaViewModel> LabelQuotas { get; set; }
        public bool IsCustomPlan { get; set; }
        public int LabelsFreeQuotaAvailable { get; set; }
        public bool AllocationRulesAdvanced { get; set; }
        public bool AllocationRulesBasic { get; set; }
        public bool ApiFeed { get; set; }
        public bool BatchPrinting { get; set; }
        public string CurrencyCode { get; set; }
        public bool CarrierServicesDomestic { get; set; }
        public bool CarrierServicesInternational { get; set; }
        public decimal RecurringCost { get; set; }
        public bool CSVUpload { get; set; }
        public int FreeLabelAllowance { get; set; }
        public bool ManualEntry { get; set; }
        public string Name { get; set; }
        public Guid Reference { get; set; }
        public int AdditionalCarriersQuota { get; set; }
        public int AdditionalCarrierServicesQuota { get; set; }
        public string SubscriptionBillingCycle { get; set; }
        public int SubscriptionLabelsPrintedInCycle { get; set; }
        public DateTime? SubscriptionLastPaymentDate { get; set; }
        public int SubscriptionMarketQuota { get; set; }
        public int SubscriptionMPDLabelsPrintedInBillCycle { get; set; }
        public DateTime? SubscriptionNextPaymentDate { get; set; }
        public Guid SubscriptionReference { get; set; }
        public string SubscriptionStatus { get; set; }

        //public IList<LabelQuotaViewModel> LabelCostTier { get; set; }
        //public string Reference { get; set; }
        //public string Name { get; set; }
        //public decimal RecurringCost { get; set; }
        //public int? FreeLabelAllowance { get; set; }
        //public bool BatchPrinting { get; set; }
        //public int AdditionalCarriersQuota { get; set; }
        //public bool CarrierServicesDomestic { get; set; }
        //public bool CarrierServicesInternational { get; set; }
        //public bool AllocationRulesBasic { get; set; }
        //public bool AllocationRulesAdvanced { get; set; }
        //public bool ManualEntry { get; set; }
        //public bool CsvUpload { get; set; }
        //public bool ApiFeed { get; set; }
        //public bool IsCustomPlan { get; set; }
        //public string Status { get; set; }
        //public bool IsCustomerPlan { get; set; }
    }
}