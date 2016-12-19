using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentValidation.Attributes;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using Spa.StarterKit.React.ViewModels.AddressLookup;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;
using Spa.StarterKit.React.ViewModels.Carrier;
using Spa.StarterKit.React.ViewModels.Configuration.PackagingSizes;
using Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload;

namespace Spa.StarterKit.React.ViewModels.Allocation.ManualUpload
{
    [Validator(typeof(CollectionDeliveryViewModelValidator))]
    public class CreateConsignmentViewModel
    {
        public CreateConsignmentViewModel()
        {
            ShippingLocations = new List<ShippingLocation>();
            ServiceGroups = new List<ServiceGroupViewModel>();
            PackageSizes = new List<PackagingSizeViewModel>();
            Countries = new List<CountryViewModel>();
            Packages = new List<PackageViewModel>();
            Consignment = new ConsignmentViewModel();
            CustomsDocumentation = new CustomsDocumentationViewModel();
	        Titles = new List<string>();
        }

        public int MaxPackages { get; set; }

        public ShippingType ShippingType { get; set; }

        // Collections for display
        public List<ShippingLocation> ShippingLocations { get; set; }
        public List<ServiceGroupViewModel> ServiceGroups { get; set; }
        public List<PackagingSizeViewModel> PackageSizes { get; set; }
        public List<CountryViewModel> Countries { get; set; }
        public List<CurrencyViewModel> Currencies { get; set; }
        public List<CarrierViewModel> AvailableCarriers { get; set; }
        public List<System.Collections.Generic.KeyValuePair<int, string>> ShippingTypes { get; set; }
        public List<System.Collections.Generic.KeyValuePair<int, string>> ReasonsForExport { get; set; }
        public List<System.Collections.Generic.KeyValuePair<int, string>> ShippingTerms { get; set; }
		public List<string> Titles { get; set; } 

        // User choices
        public ConsignmentViewModel Consignment { get; set; }
        public List<PackageViewModel> Packages { get; set; }
        public CustomsDocumentationViewModel CustomsDocumentation { get; set; }

        public PackageSize SelectedPackageSize { get; set; }

        [Display(Name = "All packages are the same?")]
        public bool AllPackagesSame { get; set; }

        [Display(Name = "How many packages?")]
        public int NumberOfPackages { get; set; }

        [Display(Name = "Allocation")]
        public AllocationOption AllocationOption { get; set; }

        [Display(Name = "Services")]
        public QueueOption QueueOption { get; set; }

        [Display(Name = "Shipping date")]
        public ShippingDateOption ShippingDateOption { get; set; }

        [Display(Name = "Estimated delivery date")]
        public DeliveryDateOption DeliveryDateOption { get; set; }

        [Display(Name = "Drop-off at")]
        public DropOffOption DropOffOption { get; set; }

        [Display(Name = "Carriers")]
        public CarrierSelectionOption CarrierSelectionOption { get; set; }

        [Display(Name="Carrier")]
        public string SelectedCarrierCode { get; set; }

        public string ServiceGroup { get; set; }

        public string DropOffPostcodeSource { get; set; }

        public DateTime? SelectedShippingDate { get; set; }
        public bool SelectedShippingDateIsToBeExact { get; set; }

        public DateTime? SelectedDeliveryDate { get; set; }

        public string SelectedDropOffLocation { get; set; }

        public string SelectedPickUpLocation { get; set; }

        public string SelectedScheduledOrAdhocServiceCode { get; set; }

        public RequestedDeliveryDate RequestedDeliveryDate { get; set; }

        public List<System.Collections.Generic.KeyValuePair<int, string>> BarcodeOptions { get; set; }
    }
}
