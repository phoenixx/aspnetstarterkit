using System;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;

namespace Spa.StarterKit.React.ViewModels.Allocation.ManualUpload
{
    public class CustomsDocumentationViewModel
    {
        public CustomsDocumentationViewModel()
        {
        }

        public string ShippersVatNumber { get; set; }
        public string RecipientsVatNumber { get; set; }
        public bool Visible { get; set; }

        public CategoryType CategoryType { get; set; }
        public ShippingTerms ShippingTerms { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? DeclarationDate { get; set; }
        public string DesignatedPersonResponsible { get; set; }
        public string ImportersVatNumber { get; set; }
        public string ReferencesOfAttachedInvoices { get; set; }
        public string ReceiversTaxCode { get; set; }
        public string ReferencesOfAttachedCertificates { get; set; }
        public string ImportersTaxCode { get; set; }
        public string ImportersFax { get; set; }
        public string CN23Comments { get; set; }
        public string ReferencesOfAttachedLicences { get; set; }
        public string CategoryTypeExplanation { get; set; }
        public string ImportersTelephone { get; set; }
        public string ImportersEmail { get; set; }
        public string OfficeOfPosting { get; set; }
        public string ShipperCustomsReference { get; set; }
    }


}
