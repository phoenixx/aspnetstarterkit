using System.Collections.Generic;
using FluentValidation.Attributes;
using Spa.StarterKit.React.ViewModels.FluentValidators.ManualUpload;

namespace Spa.StarterKit.React.ViewModels.Allocation
{
    [Validator(typeof(ItemViewModelValidator))]
    public class ItemViewModel
    {
        public string Key { get; set; }

        public string Sku { get; set; }

        public string DisplayName { get; set; }

        public string CountryOfOrigin { get; set; }

        public string HarmonisationCode { get; set; }

        public decimal Value { get; set; }

        public string Currency { get; set; }

        public decimal Weight { get; set; }

        public decimal Length { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public string Status { get; set; }

        public string CustomerReference { get; set; }

        public string ItemReferenceProvidedByCustomer { get; set; }

        public string Reference { get; set; }

        public List<MetaDataViewModel> MetaData { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public int? BarcodeType { get; set; }

        public string Barcode { get; set; }

        public string Model { get; set; }
    }
}
