using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.Customers;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Subscriptions;
using Spa.StarterKit.React.Extensions;

namespace Spa.StarterKit.React.ViewModels.Customer
{
    public class CustomerSubscriptionPlanViewModel
    {
        public string CustomerReference { get; set; }
        public CustomerReference Reference { get; set; }
        public string CustomerName { get; set; }

        public string BillingCycle { get; set; }
        public string Status { get; set; }
        public string SubscriptionPlanReferenceString { get; set; }

        public int AdditionalCarriersLimit { get; set; }
        public int AdditionalCarrierServicesLimit { get; set; }
        public DateTime NextPaymentDate { get; set; }

        public List<SubscriptionPlanContractViewModel> AvailablePlans { get; set; }
        private static SelectList _billingCycles;
        public SelectList BillingCycles
        {
            get
            {
                if (_billingCycles == null)
                {
                    var dictionary = new Dictionary<int, string>();
                    foreach (var value in Enum.GetValues(typeof(BillingCycle)))
                    {
                        dictionary.Add((int) value, ((BillingCycle) value).ToDescription());
                    }

                    _billingCycles = new SelectList(dictionary, "Key", "Value");
                }
                return _billingCycles;
            }
            set { }
        }
    }
}