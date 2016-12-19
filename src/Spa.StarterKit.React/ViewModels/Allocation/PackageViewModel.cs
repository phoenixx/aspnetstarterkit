using System.Collections.Generic;
using FluentValidation.Attributes;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using Spa.StarterKit.React.ViewModels.Allocation.Enums;
using Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload;
using Currency = Spa.StarterKit.React.ViewModels.Allocation.Enums.Currency;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    [Validator(typeof(PackageViewModelValidator))]
    public class PackageViewModel
    {
        public string Reference { get; set; }
        public string PackageReferenceProvidedByCustomer { get; set; }
        //public string Key { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public decimal? Weight { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Currency Currency { get; set; }
        public string PackageSizeReference { get; set; }
        public Barcode Barcode { get; set; }

        public PackageSplitMode PackageSplitMode { get; set; }
        public int? DesiredNumberOfPackages { get; set; }

        public List<ItemViewModel> Items { get; set; }

        public ShippingTerms ShippingTerms { get; set; }

        public List<MetaDataViewModel> MetaData { get; set; }

        public string CurrencyIsoCode { get; set; }

        public void ClearPhysicalDescription()
        {
            Width = null;
            Height = null;
            Length = null;
            Weight = null;
        }
    }
}