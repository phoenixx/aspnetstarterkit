using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;
using MPD.Electio.SDK.NetCore.Interfaces;

namespace Spa.StarterKit.React.Config
{
    public class Endpoints : IEndpoints
    {
        private static IConfigurationSection _endpoints;

        public Endpoints()
        {
            Debug.WriteLine("Getting new _endpoints");
            var environment = Environment.GetEnvironmentVariable("Environment");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .AddJsonFile($"appSettings.{environment}.json", optional: true);
            var config = builder.Build();
            var endpointsection = config.GetSection("Endpoints");

            foreach (var k in endpointsection.AsEnumerable())
            {
                Debug.WriteLine($"Endpoint: {k.Key} : {k.Value}");
            }

            _endpoints = endpointsection;
        }

        public string Subscription => _endpoints["Endpoint_Subscription"];
        public string Account => _endpoints["Endpoint_Account"];

        public string Security
        {
            get
            {
                return _endpoints["Endpoint_Security"];
            }
        } 
        public string AllocationRules => _endpoints["Endpoint_AllocationRules"];
        public string CarrierServices => _endpoints["Endpoint_CarrierServices"];
        public string Carriers => _endpoints["Endpoint_Carriers"];
        public string CarrierAccounts => _endpoints["Endpoint_CarrierAccounts"];
        public string CollectionCalendar => _endpoints["Endpoint_CollectionCalendar"];
        public string Counter => _endpoints["Endpoint_Counter"];
        public string CustomerCarrierServices => _endpoints["Endpoint_CustomerCarrierServices"];
        public string LabelGeneration => _endpoints["Endpoint_LabelGeneration"];
        public string CustomerAccounts => _endpoints["Endpoint_CustomerAccounts"];
        public string CustomerDocuments => _endpoints["Endpoint_CustomerDocuments"];
        public string Customers => _endpoints["Endpoint_Customers"];
        public string PackageSize => _endpoints["Endpoint_PackageSize"];
        public string Rates => _endpoints["Endpoint_Rates"];
        public string Role => _endpoints["Endpoint_Role"];
        public string ServiceGroups => _endpoints["Endpoint_ServiceGroups"];
        public string ShippingLocations => _endpoints["Endpoint_ShippingLocations"];
        public string SecurityStaticData => _endpoints["Endpoint_StaticData"];
        public string Tracking => _endpoints["Endpoint_Tracking"];
        public string RatesStaticData => _endpoints["Endpoint_RatesStaticData"];
        public string RatesCustomers => _endpoints["Endpoint_RatesCustomers"];
        public string RatesManagement => _endpoints["Endpoint_RatesManagement"];
        public string Address => _endpoints["Endpoint_Address"];
        public string ServiceAvailability => _endpoints["Endpoint_ServiceAvailability"];

        public string Consignment
        {
            get
            {
                return _endpoints["Endpoint_Consignment"];
            }
        }

        public string ConsignmentCreation
        {
            get
            {
                return _endpoints["Endpoint_ConsignmentCreation"];
            }
        }

        public string ConsignmentUpdation
        {
            get
            {
                return _endpoints["Endpoint_ConsignmentUpdation"];
            }
        } 

        public string Quotes => _endpoints["Endpoint_Quotes"];
        public string ConsignmentAllocation => _endpoints["Endpoint_ConsignmentAllocation"];
        public string Packages => _endpoints["Endpoint_Packages"];
        public string Items => _endpoints["Endpoint_Items"];
        public string Payments => _endpoints["Endpoint_Payments"];
        public string Invoice => _endpoints["Endpoint_Invoice"];
        public string PaymentCustomers => _endpoints["Endpoint_PaymentCustomers"];
        public string ConsignmentCustomers => _endpoints["Endpoint_ConsignmentCustomers"];
        public string Reports => _endpoints["Endpoint_Reports"];
        public string Reconciliation => _endpoints["Endpoint_Reconciliation"];
        public string Tolerance => _endpoints["Endpoint_Tolerance"];
        public string PayPal => _endpoints["Endpoint_PayPal"];
        public string BankCard => _endpoints["Endpoint_BankCard"];
        public string CarrierBooking => _endpoints["Endpoint_CarrierBooking"];
        public string CarrierBookingDocumentation => _endpoints["Endpoint_CarrierBookingDocumentation"];
        public string CarrierBookingSchedule => _endpoints["Endpoint_CarrierBookingSchedule"];
        public string CarrierBookingGatewayConfig => _endpoints["Endpoint_CarrierBookingGatewayConfig"];
        public string PickUpLocation => _endpoints["Endpoint_PickUpLocation"];
        public string ConsignmentDocuments => _endpoints["Endpoint_ConsignmentDocuments"];
        public string MetadataDictionary => _endpoints["Endpoint_MetadataDictionary"];
        public string DeliveryOptions => _endpoints["Endpoint_DeliveryOptions"];
        public string PickupOptions => _endpoints["Endpoint_PickupOptions"];
        public string CarrierServiceAccountSettings => _endpoints["Endpoint_CarrierServiceAccountSettings"];
        public string CarrierBookingAdmin => _endpoints["Endpoint_CarrierBookingAdmin"];
        public string RatesAdmin => _endpoints["Endpoint_RatesAdmin"];
        public string TrackingAdmin => _endpoints["Endpoint_TrackingAdmin"];
        public string CarrierBookingGatewayType => _endpoints["Endpoint_CarrierBookingGatewayType"];
    }
}