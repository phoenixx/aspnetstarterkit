using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using MPD.Electio.SDK.NetCore.DataTypes.Rates.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Reconciliation.v1_1;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Reconciliation;
using MPD.Electio.SDK.NetCore.Internal.Mapping;
using Spa.StarterKit.React.Config.Mapping.ValueResolvers;
using Spa.StarterKit.React.Extensions;
using Spa.StarterKit.React.ViewModels.Allocation;
using Spa.StarterKit.React.ViewModels.InvoiceReconciliation;
using Spa.StarterKit.React.ViewModels.Shared;
using Consignment = MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Consignment;
using RequestedDeliveryDate = MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.RequestedDeliveryDate;

namespace Spa.StarterKit.React.Config.Mapping.Profiles.ServiceInterfaceToViewModel
{
    public class ConsignmentsProfile : Profile
    {
        public ConsignmentsProfile()
        {
            CreateMap<Consignment, ConsignmentDetailViewModel>()
                .ForMember(dest => dest.CollectionDate, opt => opt.MapFrom(src => src.CollectionDate.HasValue ? src.CollectionDate : (DateTimeOffset?)null))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.DateCreated.UtcDateTime))
                .ForMember(dest => dest.DestinationAddress,
                    opt => opt.ResolveUsing(new ConsignmentFriendlyApiDestinationAddressCustomResolver()))
                .ForMember(dest => dest.Selected, opt => opt.Ignore())
                .ForMember(dest => dest.CarrierServiceCode, opt => opt.Ignore())
                .ForMember(dest => dest.ClientReference,
                    opt => opt.MapFrom(src => src.ConsignmentReferenceProvidedByCustomer))
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source))
                .ForMember(dest => dest.ServiceGroupReference,
                    opt =>
                        opt.MapFrom(src => NullSafeValueOf(src.Allocation, alloc => alloc.CarrierServiceGroupReference)))
                .ForMember(dest => dest.ServiceGroupName,
                    opt =>
                        opt.MapFrom(src => NullSafeValueOf(src.Allocation, alloc => alloc.MpdCarrierServiceGroupName)))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight.Kg))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.ConsignmentReference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.EarliestDeliveryDate, opt => opt.MapFrom(src => src.EarliestDeliveryDate.HasValue ? src.EarliestDeliveryDate : (DateTimeOffset?)null))
                .ForMember(dest => dest.Allocation, opt => opt.MapFrom(src => src.Allocation))
                .ForMember(dest => dest.CarrierServiceCode,
                    opt =>
                        opt.MapFrom(
                            src => NullSafeValueOf(src.Allocation, alloc => alloc.MpdCarrierServiceReference.ToString())))
                .ForMember(dest => dest.CarrierServiceName,
                    opt => opt.MapFrom(src => NullSafeValueOf(src.Allocation, alloc => alloc.MpdCarrierServiceName)))
                .ForMember(dest => dest.DateLabelsWereFirstPrinted,
                    opt => opt.MapFrom(src => src.DateLabelsWereFirstPrinted))
                .ForMember(dest => dest.HaveLabelsEverBeenPrinted, opt => opt.MapFrom(src => src.LabelsPrinted))
                .ForMember(dest => dest.RequestedDeliveryDate, opt => opt.ResolveUsing(ResolveRequestedDeliveryDate))
                .ForMember(dest => dest.FailedAllocation, opt => opt.MapFrom(src => src.FailedAllocation))
                .ForMember(dest => dest.ConsignmentState, opt => opt.MapFrom(src => src.ConsignmentState.UnCamelCase()))
                .ForMember(dest => dest.IsLate, opt => opt.MapFrom(src => src.IsLate))
                .ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.CollectionDate))
                .ForMember(dest => dest.ShippingDate, opt => opt.MapFrom(src => src.ShippingDate))
                .IgnoreMany(
                    dest => dest.CarrierCode,
                    dest => dest.CarrierName,
                    dest => dest.ShippingLocationReference,
                    dest => dest.FailedManifestMessage,
                    dest => dest.FailedManifestTimeStamp,
                    dest => dest.TrackingReference)
                    ;

            CreateMap<Consignment, ConsignmentViewModel>()
                .ForMember(dest => dest.ScheduledDeliveryDate, opt => opt.MapFrom(src => src.LatestDeliveryDate.HasValue ? src.LatestDeliveryDate.Value.Date : (DateTime?)null))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => src.DateCreated.UtcDateTime))
                .ForMember(dest => dest.CollectionDate, opt => opt.MapFrom(src => src.CollectionDate.HasValue ? src.CollectionDate.ToString() : string.Empty))
                .ForMember(dest => dest.ServiceGroupReference,
                    opt =>
                        opt.MapFrom(src => NullSafeValueOf(src.Allocation, alloc => alloc.CarrierServiceGroupReference)))
                .ForMember(dest => dest.ServiceGroupName,
                    opt =>
                        opt.MapFrom(src => NullSafeValueOf(src.Allocation, alloc => alloc.MpdCarrierServiceGroupName)))
                .ForMember(dest => dest.CarrierServiceName,
                    opt => opt.MapFrom(src => NullSafeValueOf(src.Allocation, alloc => alloc.MpdCarrierServiceName)))
                .ForMember(dest => dest.CarrierServiceCode,
                    opt =>
                        opt.MapFrom(
                            src => NullSafeValueOf(src.Allocation, alloc => alloc.MpdCarrierServiceReference.ToString())))
                .ForMember(dest => dest.ClientReference,
                    opt => opt.MapFrom(src => src.ConsignmentReferenceProvidedByCustomer))
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source))
                .ForMember(dest => dest.ConsignmentReference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.CustomerReference, opt => opt.MapFrom(src => src.CustomerReference))
                .ForMember(dest => dest.ConsignmentState, opt => opt.MapFrom(src => src.ConsignmentState))
                .ForMember(dest => dest.OriginAddress, opt => opt.MapFrom(src => ResolveOrigin(src.Addresses)))
                .ForMember(dest => dest.DestinationAddress, opt => opt.MapFrom(src => ResolveDestination(src.Addresses)))
                .ForMember(dest => dest.EarliestDeliveryDate, opt => opt.MapFrom(src => src.EarliestDeliveryDate))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Allocation.Price))
                .ForMember(dest => dest.FailedAllocation, opt => opt.MapFrom(src => src.FailedAllocation))
                .ForMember(dest => dest.Allocation, opt => opt.MapFrom(src => src.Allocation))
                .ForMember(dest => dest.RequestedDeliveryDate, opt => opt.ResolveUsing(ResolveRequestedDeliveryDate))
                .ForMember(dest => dest.DateLabelsWereFirstPrinted,
                    opt => opt.MapFrom(src => src.DateLabelsWereFirstPrinted))
                .ForMember(dest => dest.HaveLabelsEverBeenPrinted, opt => opt.MapFrom(src => src.LabelsPrinted))
                .ForMember(dest => dest.IsLate, opt => opt.MapFrom(src => src.IsLate))
                .ForMember(dest => dest.DeliveredDate, opt => opt.MapFrom(src => src.DateDelivered))
                .ForMember(dest => dest.ShippedDate, opt => opt.MapFrom(src => src.CollectionDate))
                .ForMember(dest => dest.ShippingDate, opt => opt.MapFrom(src => src.ShippingDate))
                .ForMember(dest => dest.ConsignmentStateSeverity,
                    opt => opt.MapFrom(src => src.ConsignmentState.UiSeverity().ToString()))
                .ForMember(dest => dest.ShippingTerms, opt => opt.MapFrom(src => src.CustomsDocumentation.ShippingTerms))
                .IgnoreMany(
                    dest => dest.TrackingReference,
                    dest => dest.CarrierName,
                    dest => dest.CarrierCode)
                //.ForAllMembers(c => c.IgnoreIfSourceIsNull())
                ;

            CreateMap<MetaData, MetaDataViewModel>()
                ;//.IgnoreNonExisting();

            CreateMap<FailedAllocation, FailedAllocationViewModel>()
                ;

            CreateMap<ConsignmentSummary, ConsignmentDetailViewModel>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(src => src.DateCreated))
                .ForMember(dest => dest.DestinationAddress,
                    opt => opt.ResolveUsing<ElectioConsignmentDestinationAddressResolver>())
                .ForMember(dest => dest.Selected, opt => opt.Ignore())
                .ForMember(dest => dest.ClientReference,
                    opt => opt.MapFrom(src => src.ConsignmentReferenceProvidedByCustomer))
                .ForMember(dest => dest.Source, opt => opt.MapFrom(src => src.Source))
                .ForMember(dest => dest.ServiceGroupReference,
                    opt => opt.MapFrom(src => src.MpdCarrierServiceGroupReference))
                .ForMember(dest => dest.ServiceGroupName, opt => opt.MapFrom(src => src.MpdCarrierServiceGroupName))
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.ConsignmentReference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Allocation, opt => opt.ResolveUsing<ElectioConsignmentAllocationResolver>())
                .ForMember(dest => dest.CarrierServiceCode, opt => opt.MapFrom(src => src.MpdCarrierServiceReference))
                .ForMember(dest => dest.CarrierServiceName, opt => opt.MapFrom(src => src.MpdCarrierServiceName))
                .ForMember(dest => dest.DateLabelsWereFirstPrinted,
                    opt => opt.MapFrom(src => src.DateLabelsWereFirstPrinted))
                .ForMember(dest => dest.HaveLabelsEverBeenPrinted, opt => opt.MapFrom(src => src.LabelsPrinted))
                .ForMember(dest => dest.RequestedDeliveryDate,
                    opt => opt.ResolveUsing<ElectioConsignmentRequestedDeliveryDateResolver>())
                .ForMember(dest => dest.FailedAllocation,
                    opt => opt.ResolveUsing<ElectioConsignmentFailedAllocationResolver>())
                .ForMember(dest => dest.ConsignmentState, opt => opt.MapFrom(src => src.State.UnCamelCase()))
                .ForMember(dest => dest.IsLate, opt => opt.MapFrom(src => src.IsLate))
                .ForMember(dest => dest.FailedManifestMessage, opt => opt.MapFrom(src => src.FailedManifestMessage))
                .ForMember(dest => dest.FailedManifestTimeStamp, opt => opt.MapFrom(src => src.FailedManifestTimeStamp))
                .ForMember(dest => dest.EarliestDeliveryDate, opt => opt.MapFrom(src => src.EstimatedDeliveryDate))
                .IgnoreMany(
                    dest => dest.CarrierCode,
                    dest => dest.CarrierName,
                    dest => dest.ShippingLocationReference,
                    dest => dest.TrackingReference);
            //.ForAllMembers(c => c.IgnoreIfSourceIsNull())
            ;

            CreateMap<Rate, PriceViewModel>()
                .ForMember(dest => dest.Net, opt => opt.MapFrom(src => src.Net))
                .ForMember(dest => dest.Gross, opt => opt.MapFrom(src => src.Gross))
                .ForMember(dest => dest.Vat, opt => opt.MapFrom(src => src.VatAmount))
                ;

            CreateMap<Package, PackageViewModel>(MemberList.None)
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value.Amount))
                .ForMember(dest => dest.PackageSplitMode, opt => opt.Ignore())
                .ForMember(dest => dest.DesiredNumberOfPackages, opt => opt.Ignore())
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight.Kg))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Dimensions.Height))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Dimensions.Width))
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Dimensions.Length))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.PackageReferenceProvidedByCustomer,
                    opt => opt.MapFrom(src => src.PackageReferenceProvidedByCustomer))

                ;

            CreateMap<Address, ConsignmentAddressViewModel>()
                .ForMember(d => d.Company, o => o.MapFrom(s => s.CompanyName))
                .ForMember(d => d.CountryIsoCode, o => o.MapFrom(s => s.Country.IsoCode.TwoLetterCode))
                .ForMember(d => d.CountryRef, o => o.Ignore())
                .ForMember(d => d.County, o => o.MapFrom(s => s.Region))
                .ForMember(d => d.Email, o => o.MapFrom(s => s.Contact.Email))
                .ForMember(d => d.Forename, o => o.MapFrom(s => s.Contact.FirstName))
                .ForMember(d => d.Key, o => o.Ignore())
                .ForMember(d => d.LandlineNumber, o => o.MapFrom(s => s.Contact.LandLine))
                .ForMember(d => d.Line1, o => o.MapFrom(s => s.AddressLine1))
                .ForMember(d => d.Line2, o => o.MapFrom(s => s.AddressLine2))
                .ForMember(d => d.Line3, o => o.MapFrom(s => s.AddressLine3))
                .ForMember(d => d.ShippingLocationReference, o => o.MapFrom(s => s.ShippingLocationReference))
                .ForMember(d => d.MobileNumber, o => o.MapFrom(s => s.Contact.Mobile))
                .ForMember(d => d.PostCode, o => o.MapFrom(s => s.Postcode))
                .ForMember(d => d.SpecialInstructions, o => o.MapFrom(s => s.SpecialInstructions))
                .ForMember(d => d.Surname, o => o.MapFrom(s => s.Contact.LastName))
                .ForMember(d => d.Title, o => o.MapFrom(s => s.Contact.Title))
                .ForMember(d => d.Reference, o => o.Ignore());

            CreateMap<Item, ItemViewModel>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value.Amount))
                .ForMember(dest => dest.BarcodeType, opt => opt.MapFrom(src => src.Barcode.BarcodeType))
                .ForMember(dest => dest.Barcode, opt => opt.MapFrom(src => src.Barcode.Code))
                .ForMember(dest => dest.CountryOfOrigin,
                    opt => opt.MapFrom(src => src.CountryOfOrigin.IsoCode.TwoLetterCode))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Value.Currency.IsoCode))
                .ForMember(dest => dest.CustomerReference, opt => opt.Ignore())
                .ForMember(dest => dest.DisplayName, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.HarmonisationCode, opt => opt.MapFrom(src => src.HarmonisationCode))
                .ForMember(dest => dest.Height, opt => opt.MapFrom(src => src.Dimensions.Height))
                .ForMember(dest => dest.Key, opt => opt.Ignore())
                .ForMember(dest => dest.Length, opt => opt.MapFrom(src => src.Dimensions.Length))
                .ForMember(dest => dest.Sku, opt => opt.MapFrom(src => src.Sku))
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.Weight, opt => opt.MapFrom(src => src.Weight.Kg))
                .ForMember(dest => dest.Width, opt => opt.MapFrom(src => src.Dimensions.Width))
                .ForMember(dest => dest.ItemReferenceProvidedByCustomer, opt => opt.MapFrom(src => src.ItemReferenceProvidedByCustomer))
                .ForMember(dest => dest.Model, opt => opt.MapFrom(src => src.Model))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(s => s.Quantity))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(s => s.Unit))
                ;

            CreateMap<MatchingConsignmentsResponse, MatchingConsignmentsViewModel>()
                .ForMember(dest => dest.ElectioConsignments, opt => opt.MapFrom(src => src.ConsignmentSummaries))
                .ForMember(dest => dest.TotalMatchingCount, opt => opt.MapFrom(src => src.Count));

            CreateMap<Allocation, AllocationViewModel>()
                .ForMember(dest => dest.AllocationDate, opt => opt.MapFrom(src => src.AllocationDate))
                .ForMember(dest => dest.CarrierServiceGroupReference,
                    opt => opt.MapFrom(src => src.CarrierServiceGroupReference))
                .ForMember(dest => dest.MpdCarrierServiceGroupName,
                    opt => opt.MapFrom(src => src.MpdCarrierServiceGroupName))
                .ForMember(dest => dest.MpdCarrierServiceName, opt => opt.MapFrom(src => src.MpdCarrierServiceName))
                .ForMember(dest => dest.MpdCarrierServiceReference,
                    opt => opt.MapFrom(src => src.MpdCarrierServiceReference))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));

            CreateMap<Rate, RateViewModel>()
                .ForMember(dest => dest.GrossAmount, opt => opt.MapFrom(src => src.Gross))
                .ForMember(dest => dest.NetAmount, opt => opt.MapFrom(src => src.Net))
                .ForMember(dest => dest.VatAmount, opt => opt.MapFrom(src => src.VatAmount))
                .ForMember(dest => dest.VatRate, opt => opt.MapFrom(src => src.VatRate));

            CreateMap<RequestedDeliveryDate, ViewModels.Allocation.ManualUpload.RequestedDeliveryDate>()
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                .ForMember(dest => dest.IsToBeExactlyOnTheDateSpecified,
                    opt => opt.MapFrom(src => src.IsToBeExactlyOnTheDateSpecified));

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.KeyValuePair<string, int>, KeyValuePair<string, int>>();

            CreateMap<InvoiceReconciliationFile, InvoiceReconciliationFileViewModel>(MemberList.None)
                .ForMember(d => d.Reference, opt => opt.MapFrom(s => s.Reference))
                .ForMember(d => d.Container, opt => opt.MapFrom(s => s.Container))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.FileExtension, opt => opt.MapFrom(s => s.FileExtension))
                .ForMember(d => d.Filename, opt => opt.MapFrom(s => s.FileName))
                ;

            CreateMap<Confidence, ConfidenceViewModel>(MemberList.None)
                .ForMember(d => d.Reader, opt => opt.MapFrom(s => s.Reader))
                .ForMember(d => d.ConfidencePercent, opt => opt.MapFrom(s => s.ConfidencePercent))
                .ForMember(d => d.EncounteredException, opt => opt.MapFrom(s => s.EncounteredException))
                .ForMember(d => d.ErrorLines, opt => opt.MapFrom(s => s.ErrorLines))
                .ForMember(d => d.MatchedLines, opt => opt.MapFrom(s => s.MatchedLines))
                ;

            CreateMap<InvoiceReconciliationSummary, InvoiceReconciliationSummaryViewModel>(MemberList.None)
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.Locked, opt => opt.MapFrom(s => s.Locked))
                .ForMember(d => d.Reader, opt => opt.MapFrom(s => s.Reader))
                .ForMember(d => d.Reference, opt => opt.MapFrom(s => s.Reference))
                .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status))
                ;

            CreateMap<InvoiceReconciliation, InvoiceReconciliationViewModel>(MemberList.None)
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.Created))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.File.Description))
                .ForMember(d => d.DiscrepancyCount, opt => opt.MapFrom(s => s.LineTotals.Discrepancies))
                .ForMember(d => d.ReconciledLines, opt => opt.MapFrom(s => s.LineTotals.ReconciledLines))
                .ForMember(d => d.AcceptedDiscrepancyCount, opt => opt.MapFrom(s => s.LineTotals.AcceptedDiscrepancies))
                .ForMember(d => d.Locked, opt => opt.MapFrom(s => s.Locked))
                .ForMember(d => d.Reader, opt => opt.MapFrom(s => s.Reader))
                .ForMember(d => d.Reference, opt => opt.MapFrom(s => s.Reference));

            CreateMap<InvoiceLine, DiscrepancyViewModel>(MemberList.None)
                .ForMember(d => d.DiscrepancyType, opt => opt.MapFrom(s => s.Discrepancy.DiscrepancyType))
                .ForMember(d => d.Resolution, opt => opt.MapFrom(s => s.Discrepancy.Resolution))
                .ForMember(d => d.ResolutionInformation, opt => opt.MapFrom(s => s.Discrepancy.ResolutionInformation))
                .ForMember(d => d.ExpectedCost, opt => opt.MapFrom(s => s.ExpectedCost))
                .ForMember(d => d.MpdConsignmentReference, opt => opt.MapFrom(s => s.MpdConsignmentReference))
                .ForMember(d => d.Accepted, opt => opt.MapFrom(s => s.Discrepancy.Accepted))
                .ForMember(d => d.Lines, opt => opt.MapFrom(s => s.Failed))
                ;

            CreateMap<Discrepancy, DiscrepancyLineViewModel>()
                .ForMember(d => d.LineNumber, opt => opt.MapFrom(s => s.LineNumber))
                .ForMember(d => d.OriginalInvoiceLine, opt => opt.MapFrom(s => s.OriginalInvoiceLine))
                .ForMember(d => d.OriginalInvoiceLineFiltered, opt => opt.MapFrom(s => s.OriginalInvoiceLineFiltered))
                .ForMember(d => d.HeaderLine, opt => opt.MapFrom(s => s.HeaderLine))
                .ForMember(d => d.ActualCost, opt => opt.MapFrom(s => s.ActualCost))
                ;

            CreateMap<InvoiceLine, ReconciledLineViewModel>()
                .ForMember(d => d.LineNumber, opt => opt.MapFrom(s => s.Reconciled.Any() ? s.Reconciled.FirstOrDefault().LineNumber : 0))
                .ForMember(d => d.ActualCost, opt => opt.MapFrom(s => s.Reconciled.Sum(r => r.ActualCost)))
                .ForMember(d => d.ExpectedCost, opt => opt.MapFrom(s => s.ExpectedCost))
                .ForMember(d => d.MpdConsignmentReference, opt => opt.MapFrom(s => s.MpdConsignmentReference))
                ;

            CreateMap<Tolerance, ToleranceViewModel>(MemberList.None);

            CreateMap<MetaData, ViewModels.Metadata.MetadataItem>(MemberList.None)
                .ForMember(d => d.BoolValue, opt => opt.MapFrom(s => s.BoolValue))
                .ForMember(d => d.DateTimeValue, opt => opt.MapFrom(s => s.DateTimeValue))
                .ForMember(d => d.DecimalValue, opt => opt.MapFrom(s => s.DecimalValue))
                .ForMember(d => d.IntValue, opt => opt.MapFrom(s => s.IntValue))
                .ForMember(d => d.KeyValue, opt => opt.MapFrom(s => s.KeyValue))
                .ForMember(d => d.StringValue, opt => opt.MapFrom(s => s.StringValue));
        }

        private static string NullSafeValueOf(Allocation allocation,
            Func<Allocation, string> propertyAccessor)
        {
            return allocation != null ? propertyAccessor(allocation) : string.Empty;
        }

        private static ConsignmentAddressViewModel ResolveOrigin(IList<Address> addresses)
        {
            var originAddress =
                addresses
                    .SingleOrDefault(x => x.AddressType == ConsignmentAddressType.Origin);

            return originAddress == null
                ? new ConsignmentAddressViewModel()
                : MapConsignmentAddress(originAddress);
        }

        public static ConsignmentAddressViewModel ResolveDestination(IList<Address> addresses)
        {
            var destinationAddress =
                addresses
                    .SingleOrDefault(x => x.AddressType == ConsignmentAddressType.Destination);

            return destinationAddress == null
                ? new ConsignmentAddressViewModel()
                : MapConsignmentAddress(destinationAddress);
        }


        private ViewModels.Allocation.ManualUpload.RequestedDeliveryDate ResolveRequestedDeliveryDate(
            Consignment source)
        {
            if (source.RequestedDeliveryDate == null)
            {
                return new ViewModels.Allocation.ManualUpload.RequestedDeliveryDate()
                {
                    Date = null,
                    IsToBeExactlyOnTheDateSpecified = false
                };
            }

            return new ViewModels.Allocation.ManualUpload.RequestedDeliveryDate()
            {
                Date = source.RequestedDeliveryDate.Date,
                IsToBeExactlyOnTheDateSpecified = source.RequestedDeliveryDate.IsToBeExactlyOnTheDateSpecified
            };
        }

        private static ConsignmentAddressViewModel MapConsignmentAddress(Address source)
        {
            return new ConsignmentAddressViewModel()
            {
                Company = source.CompanyName,
                CountryIsoCode = source.Country.IsoCode.TwoLetterCode,
                CountryRef = string.Empty,
                County = source.Region,
                Email = source.Contact.Email,
                Forename = source.Contact.FirstName,
                Key = string.Empty,
                LandlineNumber = source.Contact.LandLine,
                Line1 = source.AddressLine1,
                Line2 = source.AddressLine2,
                Line3 = source.AddressLine3,
                ShippingLocationReference = source.ShippingLocationReference,
                MobileNumber = source.Contact.Mobile,
                PostCode = source.Postcode,
                SpecialInstructions = source.SpecialInstructions,
                Surname = source.Contact.LastName,
                Title = source.Contact.Title,
                Town = source.Town
            };
        }
    }

    public class ElectioConsignmentAllocationResolver : IValueResolver<ConsignmentSummary, ConsignmentDetailViewModel, AllocationViewModel>
    {
        public AllocationViewModel Resolve(ConsignmentSummary source, ConsignmentDetailViewModel destination, AllocationViewModel destMember, ResolutionContext context)
        {
            if (source.State == ConsignmentState.Allocated)
            {
                return new AllocationViewModel
                {
                    AllocationDate = source.AllocationDate.Value,
                    CarrierServiceGroupReference = source.MpdCarrierServiceGroupReference,
                    MpdCarrierServiceGroupName = source.MpdCarrierServiceGroupName,
                    MpdCarrierServiceName = source.MpdCarrierServiceName,
                    MpdCarrierServiceReference = source.MpdCarrierServiceReference,
                    Price = new RateViewModel()
                };
            }

            return null;
        }
    }

    public class ElectioConsignmentFailedAllocationResolver :
        IValueResolver<ConsignmentSummary, ConsignmentDetailViewModel, FailedAllocationViewModel>
    {
        public FailedAllocationViewModel Resolve(ConsignmentSummary source, ConsignmentDetailViewModel destination,
            FailedAllocationViewModel destMember, ResolutionContext context)
        {
            if (source.State != ConsignmentState.AllocationFailed)
                return null;

            return new FailedAllocationViewModel
            {
                MpdCarrierServiceGroupName = source.FailedAllocationMpdCarrierServiceGroupName,
                MpdCarrierServiceName = source.FailedAllocationMpdCarrierServiceName,
                MpdCarrierServiceReference = source.FailedAllocationMpdCarrierServiceReference,
                CarrierServiceGroupReference = source.FailedAllocationMpdCarrierServiceGroupReference,
                AttemptedAllocationDate = source.FailedAllocationAttemptedAllocationDate.Value,
                Message = source.FailedAllocationMessage
            };
        }
    }

    public class ElectioConsignmentDestinationAddressResolver : IValueResolver<ConsignmentSummary, ConsignmentDetailViewModel, string>
    {
        public string Resolve(ConsignmentSummary source, ConsignmentDetailViewModel destination, string destMember, ResolutionContext context)
        {
            var fields = new List<string>
            {
                source.DestinationAddressLine1,
                source.DestinationAddressTown,
                source.DestinationAddressPostcode,
                source.DestinationAddressCountry
            };

            return string.Join(", ", fields);
        }
    }

    public class ElectioConsignmentRequestedDeliveryDateResolver :
        IValueResolver<ConsignmentSummary, ConsignmentDetailViewModel, ViewModels.Allocation.ManualUpload.RequestedDeliveryDate>
    {
        public ViewModels.Allocation.ManualUpload.RequestedDeliveryDate Resolve(ConsignmentSummary source, ConsignmentDetailViewModel destination, ViewModels.Allocation.ManualUpload.RequestedDeliveryDate destMember,
            ResolutionContext context)
        {
            if (!source.RequestedDeliveryDate.HasValue)
            {
                return null;
            }

            return new ViewModels.Allocation.ManualUpload.RequestedDeliveryDate
            {
                Date = source.RequestedDeliveryDate.Value.Date,
                IsToBeExactlyOnTheDateSpecified =
                    source.RequestedDeliveryDateIsToBeExactlyOnTheDateSpecified.GetValueOrDefault(false)
            };
        }
    }
}