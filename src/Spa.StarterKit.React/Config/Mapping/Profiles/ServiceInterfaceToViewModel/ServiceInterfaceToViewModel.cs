using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using MPD.Electio.SDK.NetCore.DataTypes.Accounts.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.CarrierServiceDirectory.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Enums;
using MPD.Electio.SDK.NetCore.DataTypes.Profile.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.Security.v1_1;
using MPD.Electio.SDK.NetCore.DataTypes.ServiceAvailability.v1_1;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.ContactInfo;
using MPD.Electio.SDK.NetCore.Internal.CoreLib.Locations.Addresses.Postcodes;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Accounts;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.AddressLookup;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Carriers;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Common;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.CustomerCarrierServices;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Rates;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Reconciliation;
using MPD.Electio.SDK.NetCore.Internal.DataTypes.Subscriptions;
using Spa.StarterKit.React.ViewModels.AddressLookup;
using Spa.StarterKit.React.ViewModels.Allocation.ManualUpload;
using Spa.StarterKit.React.ViewModels.Company;
using Spa.StarterKit.React.ViewModels.Company.CarrierRanges;
using Spa.StarterKit.React.ViewModels.Configuration;
using Spa.StarterKit.React.ViewModels.Configuration.CarrierServiceGroups;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar;
using Spa.StarterKit.React.ViewModels.Configuration.CollectionCalendar.Enums;
using Spa.StarterKit.React.ViewModels.Configuration.PackagingSizes;
using Spa.StarterKit.React.ViewModels.Configuration.Rates;
using Spa.StarterKit.React.ViewModels.Configuration.ShippingRules;
using Spa.StarterKit.React.ViewModels.Configuration.Zones;
using Spa.StarterKit.React.ViewModels.Customer;
using Spa.StarterKit.React.ViewModels.Dashboard;
using Spa.StarterKit.React.ViewModels.InvoiceReconciliation;
using Spa.StarterKit.React.ViewModels.Profile;
using Spa.StarterKit.React.ViewModels.Roles;
using Spa.StarterKit.React.ViewModels.Shared.Account;
using Spa.StarterKit.React.ViewModels.Shared.Address;
using Spa.StarterKit.React.ViewModels.Shared.CarriersAndServices;
using Spa.StarterKit.React.ViewModels.Shared.Company;
using Spa.StarterKit.React.ViewModels.Shared.RolesAndPermissions;
using Spa.StarterKit.React.ViewModels.Subscriptions;
using Spa.StarterKit.React.ViewModels.Tracking;
using Spa.StarterKit.React.ViewModels.User;

namespace Spa.StarterKit.React.Config.Mapping.Profiles.ServiceInterfaceToViewModel
{
    public class ServiceInterfaceToViewModelMaps : Profile
    {
        public ServiceInterfaceToViewModelMaps()
        {
            ConfigureMaps();
        }

        private void ConfigureMaps()
        {

            CreateMap<VatRate, VatRateViewModel>(MemberList.None)
                .ForMember(dest => dest.Label, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(s => s.Type))
                ;

            CreateMap<SubscriptionPlanContract, AddSubscriptionPlanViewModel>(MemberList.None);

            CreateMap<List<CarrierRange>, ManageCarrierRangesViewModel>()
                .ConvertUsing(new Func<List<CarrierRange>, ManageCarrierRangesViewModel>(list =>
                {

                    var result =
                        list.GroupBy(x => x.CarrierAccountReference)
                            .ToList()
                            .Select(x => new ManageCarrierRangesViewModel()
                            {
                                CustomerReference = x.First().CustomerReference,
                                CarrierReference = x.First().CarrierReference,
                                CarrierAccountReference = x.First().CarrierAccountReference,
                                GatewayTypeId = x.First().GatewayTypeId,
                                CarrierRanges = x.GroupBy(y => y.CounterName)
                                .ToList()
                                .Select(y => new CarrierRangeViewModel()
                                {
                                    IsTemplate = y.First().IsTemplate,
                                    IsCircular = y.First().IsCircular,
                                    RangeName = y.First().CounterName,
                                    RangeDescription = y.First().CounterDescription,
                                    Ranges = y.Select(z => new RangeViewModel()
                                    {
                                        Id = z.Id,
                                        Start = z.Start,
                                        End = z.End,
                                        Step = z.Step,
                                        IsCurrent = z.IsCurrent,
                                        Order = z.Order,
                                        RecordIsNotInDatabase = z.RecordIsNotInDatabase
                                    }).ToList()
                                }).ToList()
                            })
                            .First(); // should only be one record when grouped by carrier account reference

                    return result;
                }))
                ;

            CreateMap<MpdCarrierService, SimpleCarrierViewModel>(MemberList.None)
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CarrierName))
                .ForMember(dest => dest.CarrierServices, opt => opt.Ignore()) //TEMP
                
                ;

            CreateMap<MpdCarrier, SimpleCarrierViewModel>(MemberList.None)
                .ForMember(dest => dest.CarrierServices, opt => opt.MapFrom(src => src.MpdCarrierServices))
                ;

            CreateMap<MpdCarrierService, SimpleCarrierServiceViewModel>(MemberList.None);
                ;

            CreateMap<MpdCarrierService, CarrierServiceViewModel>(MemberList.None)
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.CarrierName, opt => opt.MapFrom(src => src.CarrierName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.CarrierReference, opt => opt.MapFrom(src => src.MpdCarrierReference))
                .ForMember(dest => dest.CarrierAccountReference,
                    opt => opt.UseValue("Not Applicable to MPD Carrier Service"))
                .ForMember(dest => dest.MaintainCosts, opt => opt.MapFrom(src => src.MaintainCosts))
                
                ;

            CreateMap<MpdCarrierServiceProfile, CarrierServiceViewModel>(MemberList.None)
                .ForMember(d => d.CarrierAccountOwner, opt => opt.MapFrom(s => s.MpdCarrierService.CarrierAccountOwner))
                .ForMember(d => d.CarrierAccountReference,
                    opt => opt.UseValue("Not Applicable to MPD Carrier Service"))
                .ForMember(d => d.CarrierName, opt => opt.MapFrom(s => s.MpdCarrierService.CarrierName))
                .ForMember(d => d.CarrierReference, opt => opt.MapFrom(s => s.MpdCarrierService.MpdCarrierReference))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.MpdCarrierService.Description))
                .ForMember(d => d.IsEnabled, opt => opt.MapFrom(s => s.IsEnabled))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.MpdCarrierService.Name))
                .ForMember(d => d.Reference, opt => opt.MapFrom(s => s.MpdCarrierService.Reference))
                
                ;


            CreateMap<MpdCarrierServiceGroup, CarrierServiceGroupViewModel>(MemberList.None)
                .ForMember(dest => dest.CarrierServices, opt => opt.MapFrom(src => src.MpdCarrierServiceProfiles))
                .ForMember(d => d.IsEnabled, opt => opt.MapFrom(s => s.MpdCarrierServiceProfiles.Any(x => x.IsEnabled)))
                
                ;

            CreateMap<IList<MpdCarrierServiceGroup>, CarrierServiceGroupsViewModel>(MemberList.None)
                .ForMember(dest => dest.CarrierServiceGroups, opt => opt.MapFrom(src => src))
                
                ;

            CreateMap<MpdCarrierServiceGroup, ServiceGroupViewModel>(MemberList.None)
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(d => d.IsEnabled, opt => opt.MapFrom(s => s.MpdCarrierServiceProfiles.Any(x => x.IsEnabled)))
                
                ;

            CreateMap<ShippingLocation, ShippingLocationItemViewModel>(MemberList.None)
                .ForMember(dest => dest.Address, opt => opt.ResolveUsing(from => new AddressViewModel
                {
                    Line1 = from.AddressLine1,
                    Line2 = from.AddressLine2,
                    Line3 = from.AddressLine3,
                    Town = from.Town,
                    County = from.Region,
                    PostCode = from.Postcode,
                    Country = from.Country.Name,
                    CountryIsoCode = from.Country.IsoCode.TwoLetterCode,
                    Company = from.CompanyName,
                    SpecialInstructions = from.SpecialInstructions,
                    Reference = from.Reference
                }));

            CreateMap<ShippingLocation, ShippingLocationViewModel>(MemberList.None)
                .ForMember(dest => dest.ContactTitle,
                    opt => opt.MapFrom(src => src.Contact.Title))
                .ForMember(dest => dest.ContactFirstName,
                    opt => opt.MapFrom(src => src.Contact.FirstName))
                .ForMember(dest => dest.ContactLastName,
                    opt => opt.MapFrom(src => src.Contact.LastName))
                .ForMember(dest => dest.ContactTelephone,
                    opt => opt.MapFrom(src => src.Contact.Telephone))
                .ForMember(dest => dest.Email,
                    opt => opt.MapFrom(src => src.Contact.Email))
                .ForMember(dest => dest.IsDefaultReturnLocation,
                    opt => opt.MapFrom(src => src.DefaultLocationForReturns))
                .ForMember(dest => dest.JobTitle,
                    opt => opt.MapFrom(src => src.Contact.Position))
                .ForMember(dest => dest.ShippingLocationId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.LocationName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.NotesToCarrier, opt => opt.MapFrom(src => src.Notes))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.ShippingLocationType))
                .ForMember(dest => dest.Address, opt => opt.ResolveUsing(from => new AddressViewModel
                {
                    Line1 = from.AddressLine1,
                    Line2 = from.AddressLine2,
                    Line3 = from.AddressLine3,
                    Town = from.Town,
                    County = from.Region,
                    PostCode = from.Postcode,
                    Country = from.Country != null ? from.Country.Name : "",
                    CountryIsoCode = from.Country != null ? from.Country.IsoCode.TwoLetterCode : "",
                    Company = from.CompanyName,
                    SpecialInstructions = from.SpecialInstructions,
                    Reference = from.Reference
                }))
                .ForMember(dest => dest.LinkedAccounts, opt => opt.MapFrom(src => src.LinkedAccounts))
                
                ;

            CreateMap<ShippingLocationAccount, ShippingLocationAccountViewModel>(MemberList.None)
                .ForMember(d => d.AccountName, opt => opt.MapFrom(s => s.AccountName))
                .ForMember(d => d.AccountReference, opt => opt.MapFrom(s => s.AccountReference));

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Address, AddressViewModel>(MemberList.None)
                .ForMember(dest => dest.Company, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.CountryIsoCode, opt => opt.MapFrom(src => src.Country.IsoCode.TwoLetterCode))
                .ForMember(dest => dest.County, opt => opt.MapFrom(src => src.Region))
                .ForMember(dest => dest.Line1, opt => opt.MapFrom(src => src.AddressLine1))
                .ForMember(dest => dest.Line2, opt => opt.MapFrom(src => src.AddressLine2))
                .ForMember(dest => dest.Line3, opt => opt.MapFrom(src => src.AddressLine3))
                .ForMember(dest => dest.Country, opt => opt.Ignore())
                .ForMember(dest => dest.PostCode, opt => opt.MapFrom(src => src.Postcode))
                .ForMember(dest => dest.SpecialInstructions, opt => opt.MapFrom(src => src.SpecialInstructions))
                .ForMember(dest => dest.SingleLineAddress,
                    opt =>
                        opt.MapFrom(src => string.Join(", ", src.AddressLine1, src.Town, src.Region, src.Country.Name)))
                .ForMember(dest => dest.Town, opt => opt.MapFrom(src => src.Town))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(s => s.ShippingLocationReference))
                ;

            CreateMap<CollectionCalendar, CollectionCalendarFormViewModel>(MemberList.None)
                .ForMember(dest => dest.CollectionExceptions, opt => opt.MapFrom(x => x.CalendarExceptions))
                .ForMember(dest => dest.CollectionTimesMon,
                    opt => opt.MapFrom(src => src.CalendarRules.Where(s => s.DayOfWeek == DayOfWeek.Monday)))
                .ForMember(dest => dest.CollectionTimesTue,
                    opt =>
                        opt.MapFrom(src => src.CalendarRules.Where(s => s.DayOfWeek == DayOfWeek.Tuesday)))
                .ForMember(dest => dest.CollectionTimesWed,
                    opt =>
                        opt.MapFrom(src => src.CalendarRules.Where(s => s.DayOfWeek == DayOfWeek.Wednesday)))
                .ForMember(dest => dest.CollectionTimesThu,
                    opt =>
                        opt.MapFrom(src => src.CalendarRules.Where(s => s.DayOfWeek == DayOfWeek.Thursday)))
                .ForMember(dest => dest.CollectionTimesFri,
                    opt => opt.MapFrom(src => src.CalendarRules.Where(s => s.DayOfWeek == DayOfWeek.Friday)))
                .ForMember(dest => dest.CollectionTimesSat,
                    opt =>
                        opt.MapFrom(src => src.CalendarRules.Where(s => s.DayOfWeek == DayOfWeek.Saturday)))
                .ForMember(dest => dest.CollectionTimesSun,
                    opt => opt.MapFrom(src => src.CalendarRules.Where(s => s.DayOfWeek == DayOfWeek.Sunday)))
                ;

            CreateMap<CalendarRule, CollectionCalendarTimeViewModel>(MemberList.None)
                .ForMember(dest => dest.PreAdviceTime,
                    opt =>
                        opt.MapFrom(
                            src =>
                                src.CalendarOperationTimes.PreAdviceTime.HasValue
                                    ? (TimeSpan?)src.CalendarOperationTimes.PreAdviceTime.Value.Time
                                    : null))
                .ForMember(dest => dest.CutOffTime,
                    opt => opt.MapFrom(src => src.CalendarOperationTimes.CutOffTime.Time))
                .ForMember(dest => dest.ManifestTime,
                    opt =>
                        opt.MapFrom(
                            src => src.CalendarOperationTimes.ManifestTime))
                .ForMember(dest => dest.PreAdviceType,
                    opt =>
                        opt.MapFrom(
                            src =>
                                src.CalendarOperationTimes.PreAdviceTime.HasValue
                                    ? -src.CalendarOperationTimes.PreAdviceTime.Value.TimeOffsetInDays
                                    : 0))
                .ForMember(dest => dest.CutOffType,
                    opt =>
                        opt.MapFrom(
                            src =>
                                -src.CalendarOperationTimes.CutOffTime.TimeOffsetInDays))
                .ForMember(dest => dest.OperationalCutOffTime,
                    opt =>
                        opt.MapFrom(
                                src =>
                                    src.CalendarOperationTimes.OperationalCutOffTime.HasValue
                                        ? (TimeSpan?)src.CalendarOperationTimes.OperationalCutOffTime.Value.Time
                                        : null))
                .ForMember(dest => dest.OperationalCutOffType,
                    opt =>
                        opt.MapFrom(
                            src =>
                                src.CalendarOperationTimes.OperationalCutOffTime.HasValue
                                    ? -src.CalendarOperationTimes.OperationalCutOffTime.Value.TimeOffsetInDays
                                    : 0))
                ;

            CreateMap<CalendarException, CollectionCalendarExceptionViewModel>(MemberList.None)
                .ForMember(dest => dest.CollectionExceptionType,
                    m =>
                        m.ResolveUsing(
                            src => Enum.Parse(typeof(CollectionExceptionType), src.CalendarExceptionType.ToString())))
                .ForMember(dest => dest.ExceptionDate, m => m.MapFrom(src => src.Date))
                .ForMember(dest => dest.CarrierCollection, m => m.MapFrom(src => src.CalendarOperationTimes))
                ;

            CreateMap<CalendarOperationTimes, CollectionCalendarTimeViewModel>(MemberList.None)
                .ForMember(dest => dest.ManifestTime,
                    m => m.MapFrom(src => src.ManifestTime))
                .ForMember(dest => dest.PreAdviceTime,
                    m => m.MapFrom(src => src.PreAdviceTime.HasValue ? (TimeSpan?)src.PreAdviceTime.Value.Time : null))
                .ForMember(dest => dest.PreAdviceType,
                    m => m.MapFrom(src => src.PreAdviceTime.HasValue ? -src.PreAdviceTime.Value.TimeOffsetInDays : 0))
                .ForMember(dest => dest.CutOffType,
                    m => m.MapFrom(src => -src.CutOffTime.TimeOffsetInDays))
                .ForMember(dest => dest.CutOffTime, m => m.MapFrom(src => -src.CutOffTime.Time))
                .ForMember(dest => dest.OperationalCutOffTime,
                    m => m.MapFrom(src => src.OperationalCutOffTime.HasValue ? (TimeSpan?)src.OperationalCutOffTime.Value.Time : null))
                .ForMember(dest => dest.OperationalCutOffType,
                    m => m.MapFrom(src => src.OperationalCutOffTime.HasValue ? -src.OperationalCutOffTime.Value.TimeOffsetInDays : 0))
                ;

            #region Accounts

            CreateMap<Account, AccountViewModel>(MemberList.None)
                .ForMember(dest => dest.AccountReference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.CompanyReference, opt => opt.MapFrom(src => src.CustomerReference))
                ;

            CreateMap<Account, AccountInfoViewModel>(MemberList.None)
                .ForMember(dest => dest.AccountReference, opt => opt.MapFrom(src => src.Reference))
                ;

            CreateMap<Account, AccountEditViewModel>(MemberList.None)
                .ForMember(dest => dest.AccountReference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.CurrentEmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.NewEmailAddress, opt => opt.MapFrom(src => src.EmailAddress))
                .ForMember(dest => dest.IsDisabled, opt => opt.MapFrom(src => !src.IsEnabled))
                ;

            CreateMap<Customer, CompanyViewModel>(MemberList.None)
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.RegistrationCountryRef,
                    opt => opt.MapFrom(src => src.RegistrationCountry.IsoCode.TwoLetterCode))
                .ForMember(dest => dest.CurrencyRef, opt => opt.MapFrom(src => src.Currency.Iso4217AlphaCode))
                .ForMember(dest => dest.PaymentModel, opt => opt.MapFrom(src => src.PaymentModel))
                
                ;

            CreateMap<Role, RoleViewModel>(MemberList.None)
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                ;

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Address, AddressEditViewModel>(MemberList.None)
                .ForMember(dest => dest.AvailableCountries, opt => opt.Ignore())
                .ForMember(dest => dest.CountryIsoCode, opt => opt.MapFrom(src => src.Country.IsoCode.TwoLetterCode))
                .ForMember(dest => dest.Line1, opt => opt.MapFrom(src => src.AddressLine1))
                .ForMember(dest => dest.Line2, opt => opt.MapFrom(src => src.AddressLine2))
                .ForMember(dest => dest.Line3, opt => opt.MapFrom(src => src.AddressLine3))
                .ForMember(dest => dest.County, opt => opt.MapFrom(src => src.Region))
                
                ;

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Common.v1_1.Address, AddressInfoViewModel>(MemberList.None)
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => new Country
                {
                    IsoCode = src.Country.IsoCode,
                    Name = src.Country.Name
                }))
                .ForMember(dest => dest.Line1, opt => opt.MapFrom(src => src.AddressLine1))
                .ForMember(dest => dest.Line2, opt => opt.MapFrom(src => src.AddressLine2))
                .ForMember(dest => dest.Line3, opt => opt.MapFrom(src => src.AddressLine3))
                .ForMember(dest => dest.County, opt => opt.MapFrom(src => src.Region))
                ;

            CreateMap<Account, BasicAccountInfoViewModel>(MemberList.None);

            CreateMap<MpdCarrier, SimpleCarrierViewModel>(MemberList.None)
                .ForMember(dest => dest.CarrierServices, opt => opt.MapFrom(src => src.MpdCarrierServices));

            CreateMap<CarrierService, SimpleCarrierServiceViewModel>(MemberList.None);

            CreateMap<MpdCarrier, SimpleCarrierViewModel>(MemberList.None)
                .ForMember(dest => dest.CarrierServices, opt => opt.MapFrom(src => src.MpdCarrierServices))
                .ForMember(dest => dest.HasSelectedServices, opt => opt.Ignore()) //TODO
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                ;

            CreateMap<CarrierService, SimpleCarrierServiceViewModel>(MemberList.None)
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.Selected, opt => opt.Ignore())
                ;


            CreateMap<CustomerAccountSummary, CustomerAccountSummaryViewModel>(MemberList.None)
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                ;

            #endregion Accounts

            CreateMap<MpdCarrierService, CarrierServiceViewModel>(MemberList.None)
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.CarrierName, opt => opt.MapFrom(src => src.CarrierName))
                .ForMember(dest => dest.CarrierReference, opt => opt.MapFrom(src => src.MpdCarrierReference))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsEnabled, opt => opt.UseValue(true))
                .ForMember(dest => dest.IsSelected, opt => opt.UseValue(false))
                .ForMember(dest => dest.IsElectioService,
                    opt => opt.MapFrom(src => src.Source == MpdCarrierServiceSource.Internal))
                .ForMember(dest => dest.MaintainCosts, opt => opt.MapFrom(src => src.MaintainCosts))
                ;

            CreateMap<CustomerCarrierService, CarrierServiceViewModel>(MemberList.None)
                .ForMember(dest => dest.Reference, opt => opt.MapFrom(src => src.Reference))
                .ForMember(dest => dest.CarrierReference, opt => opt.MapFrom(src => src.MpdCarrierReference))
                .ForMember(dest => dest.CarrierName, opt => opt.MapFrom(src => src.CarrierName))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.IsEnabled, opt => opt.MapFrom(src => src.IsEnabled))
                .ForMember(dest => dest.IsConfigured, opt => opt.MapFrom(src => src.IsConfigured))
                .ForMember(dest => dest.IsSelected, opt => opt.UseValue(false))
                .ForMember(dest => dest.CollectionType, opt => opt.MapFrom(src => src.Journey.Any() ? src.Journey.First().CollectionType.ToString() : string.Empty))
                .ForMember(dest => dest.CarrierAccountReference, opt => opt.MapFrom(src => src.Journey.Any() ? src.Journey.First().CarrierAccountReference : string.Empty))
                .ForMember(dest => dest.CarrierServiceReference, opt => opt.MapFrom(src => src.Journey.Any() ? src.Journey.First().CarrierService.Reference : string.Empty))
                ;

            CreateMap<IList<MpdCarrierService>, CarrierServicesViewModel>()
                .ConvertUsing(new Func<IList<MpdCarrierService>, CarrierServicesViewModel>(list =>
                {
                    var ccs = new CarrierServicesViewModel
                    {
                        SearchExpression = string.Empty,
                        SortParameter = string.Empty,
                        SortIsInverted = false,
                        CarrierServices = list.Select(MapCarrierServiceViewModel).ToList()
                    };

                    return ccs;
                }
                )
            );

            CreateMap<RatesDataUploadProgress, NewCostUploadProgressViewModel>(MemberList.None)
            ;

            CreateMap<MPD.Electio.SDK.NetCore.Internal.Validation.ValidationMessage, ValidationMessage>()
                .ForMember(x => x.Message, x => x.MapFrom(y => y.Message))
                .ForMember(x => x.Level, x => x.MapFrom(y => y.ValidationLevel.ToString()))
                .ForMember(x => x.Row, x => x.MapFrom(y => y.Index))
            ;

            CreateMap<Zone, ListZoneViewModel>(MemberList.None)
            ;

            CreateMap<Zone, ZoneViewModel>(MemberList.None)
                .ForMember(x => x.Endpoints, x => x.MapFrom(y => y.ZoneEndpoints))
                .ForMember(x => x.Services, x => x.MapFrom(y => y.Services))
                ;

            CreateMap<ZoneViewModel, Zone>(MemberList.None)
                .ForMember(x => x.ZoneEndpoints, x => x.MapFrom(y => y.Endpoints))
                .ForMember(x => x.Services, x => x.Ignore())
            ;
            
            CreateMap<ZoneEndpoint, EndpointViewModel>(MemberList.None)
            ;

            CreateMap<EndpointViewModel, ZoneEndpoint>(MemberList.None)
            ;

            CreateMap<Zone.Service, ZoneViewModel.ServiceViewModel>(MemberList.None)
            ;


            CreateMap<IList<CustomerCarrierService>, CarrierServicesViewModel>()
                .ConvertUsing(new Func<IList<CustomerCarrierService>, CarrierServicesViewModel>(list =>
                {
                    var ccs = new CarrierServicesViewModel
                    {
                        SearchExpression = string.Empty,
                        SortParameter = string.Empty,
                        SortIsInverted = false,
                        CarrierServices = list.Select(MapCarrierServiceViewModel).ToList()// Mapper.Map<IList<CarrierServiceViewModel>>(list)
                    };

                    return ccs;
                }
                )
            );

            #region Permissions

            CreateMap<PermissionGroup, PermissionGroupViewModel>(MemberList.None)
                .ForMember(d => d.IsEditable, opt => opt.MapFrom(src => src.Permissions.All(x => x.Type == "Custom")))
                ;

            CreateMap<Permission, PermissionViewModel>(MemberList.None)
                .ForMember(dest => dest.Selected, opt => opt.Ignore())
                .ForMember(dest => dest.IsEditable, opt => opt.Ignore())
                ;

            CreateMap<IList<Permission>, PermissionRestrictionsViewModel>()
                .ConvertUsing(PermissionRestrictionToViewModel);

            CreateMap<Permission, PermissionGroupViewModel>(MemberList.None)
                .ForMember(dest => dest.Key, opt => opt.MapFrom(src => src.Key))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Permissions, opt => opt.Ignore())
                .ForMember(dest => dest.IsEditable, opt => opt.Ignore())
                ;


            #endregion Permissions

            #region Profile

            CreateMap<MpdCarrierServiceProfile, CarrierServiceProfileViewModel>(MemberList.None)
                .ForMember(dest => dest.CompanyReference, opt => opt.MapFrom(src => src.CustomerReference))
                .ForMember(dest => dest.LocationRestrictions, opt => opt.ResolveUsing(MapLocationRestrictions))
                .ForMember(dest => dest.Service, opt => opt.MapFrom(src => src.MpdCarrierService))
                ;


            CreateMap<DimensionRestriction, DimensionRestrictionViewModel>(MemberList.None);
            CreateMap<CompensationAndValue, CompensationAndValueViewModel>(MemberList.None);

            #endregion Profile

            CreateMap<ConsignmentStateSummaryResponse, StatusSummaryResponseModel>(MemberList.None)
                .ForMember(d => d.Summary, opt => opt.ResolveUsing<ConsignmentStateSummaryResolver>());

            CreateMap<ConsignmentCarrierSummaryResponse, CarrierStatusResponseModel>(MemberList.None);
            CreateMap<ConsignmentStateByCarrierService, ConsignmentStateByCarrier>(MemberList.None);

            CreateMap<PackageSize, PackagingSizeViewModel>(MemberList.None);

            CreateMap<Country, CountryViewModel>(MemberList.None)
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(d => d.TwoLetterIsoCode, opt => opt.MapFrom(s => s.IsoCode.TwoLetterCode));

            CreateMap<AddressLookupCountry, CountryViewModel>(MemberList.None)
                .ForMember(d => d.TwoLetterIsoCode, opt => opt.MapFrom(s => s.IsoCode.TwoLetterCode))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name));


            CreateMap<Contact, MPD.Electio.SDK.NetCore.Internal.CoreLib.Consignments.CarrierConsignments.Contact>(MemberList.None)
                .ForMember(d => d.Name, opt => opt.MapFrom(s => new PersonName(s.Title, s.FirstName, string.Empty, s.LastName)))
                .ForMember(d => d.PhoneNumberLandline, opt => opt.MapFrom(s => PhoneNumber.Parse(s.Telephone)))
                .ForMember(d => d.PhoneNumberMobile, opt => opt.MapFrom(s => PhoneNumber.Parse(s.Mobile)))
                .ForMember(d => d.PhoneNumberPreferred, opt => opt.ResolveUsing(from => PhoneNumber.Parse(!string.IsNullOrWhiteSpace(from.Mobile) ? from.Mobile : from.LandLine)))
                .ForMember(d => d.EmailAddress, opt => opt.MapFrom(s => EmailAddress.Parse(s.Email)))
                
                ;

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Consignments.v1_1.Address, MPD.Electio.SDK.NetCore.Internal.CoreLib.Locations.Addresses.Address>(MemberList.None)
                .ForMember(d => d.CountyOrState, opt => opt.MapFrom(s => s.Region))
                .ForMember(d => d.CountyOrStateCode, opt => opt.MapFrom(s => s.RegionCode))
                .ForMember(d => d.Postcode, opt => opt.MapFrom(s => new Postcode(s.Postcode)))
                .ForMember(d => d.Country, opt => opt.MapFrom(s => MPD.Electio.SDK.NetCore.Internal.CoreLib.Locations.Countries.Country.FromTwoLetterIsoCode(s.Country.IsoCode.TwoLetterCode)))
                ;

            CreateMap<MPD.Electio.SDK.NetCore.Internal.DataTypes.Reconciliation.ConsignmentCostSummary, ConsignmentCostSummaryViewModel>()
                .ForMember(d => d.ConsignmentReference, opt => opt.MapFrom(s => s.Reference))
                .ForMember(d => d.ClientReference, opt => opt.MapFrom(s => s.ConsignmentReferenceProvidedByCustomer))
                .ForMember(d => d.DestinationAddress, opt => opt.MapFrom(s => s.DestinationAddressLine1))
                .ForMember(dest => dest.DestinationAddress,
                    opt => opt.ResolveUsing<ElectioConsignmentCostSummaryDestinationAddressResolver>())


                .ForMember(d => d.TotalCost, opt => opt.MapFrom(s => s.CostItems.Sum(c => c.Cost)))
                .ForMember(d => d.Created, opt => opt.MapFrom(s => s.DateCreated))
                ;


            #region Subscription Plans

            CreateMap<SubscriptionPlanContract, SubscriptionPlanContractViewModel>(MemberList.None)
                ;

            CreateMap<SubscriptionPlanContract, EditSubscriptionPlanViewModel>(MemberList.None)
                .ForMember(d => d.MpdCarrierServicesSelected, opt => opt.MapFrom(src => src.SubscriptionMpdCarrierServices.Select(x => x.MpdCarrierServiceReference)))
                ;

            #endregion


            CreateMap<SequenceMetrics, ViewSequenceMetricsViewModel>()
            ;
            #region Tracking

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Tracking.v1_1.ConsignmentViewModel, TrackingViewModel>(MemberList.None)
                .ForMember(d => d.ConsignmentReferenceForAllLegsAssignedByMpd, opt => opt.MapFrom(s => s.ConsignmentReferenceForAllLegsAssignedByMpd))
                .ForMember(d => d.TrackedPackages, opt => opt.MapFrom(s => s.TrackedPackages))
                ;

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Tracking.v1_1.PackageViewModel, TrackedPackageViewModel>(MemberList.None)
                .ForMember(d => d.PackageReferenceForAllLegsAssignedByMpd, opt => opt.MapFrom(s => s.PackageReferenceForAllLegsAssignedByMpd))
                .ForMember(d => d.Legs, opt => opt.MapFrom(s => s.Legs))
                ;

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Tracking.v1_1.LegViewModel, TrackedLegViewModel>(MemberList.None)
                .ForMember(d => d.CarrierServiceName, opt => opt.MapFrom(s => s.CarrierServiceName))
                .ForMember(d => d.Events, opt => opt.MapFrom(s => s.Events))
                ;

            CreateMap<MPD.Electio.SDK.NetCore.DataTypes.Tracking.v1_1.EventViewModel, TrackingEventViewModel>(MemberList.None)
                .ForMember(d => d.Code, opt => opt.MapFrom(s => s.Code))
                .ForMember(d => d.Description, opt => opt.MapFrom(s => s.Description))
                .ForMember(d => d.Location, opt => opt.MapFrom(s => s.Location))
                .ForMember(d => d.SignedBy, opt => opt.MapFrom(s => s.SignedBy))
                .ForMember(d => d.TimeStamp, opt => opt.MapFrom(s => s.TimeStamp))
                ;

            #endregion Tracking

            SdkToSdk();
        }

        // temp - this should probably be it's own map in infrastructure
        private void SdkToSdk()
        {
            CreateMap<CustomerCarrierService, RatesCarrierServiceCheck>()
                .ForMember(d => d.CustomerName, opt => opt.Ignore())
                .ForMember(d => d.CustomerReference, opt => opt.Ignore())
                ;
        }

        private static CarrierServiceViewModel MapCarrierServiceViewModel(CustomerCarrierService source)
        {
            return new CarrierServiceViewModel()
            {
                Reference = source.Reference,
                CarrierReference = source.MpdCarrierReference,
                // TODO: we need a collection property for multi-leg
                CarrierAccountReference = source.Journey.First()?.CarrierAccountReference,
                CarrierName = source.CarrierName,
                Description = source.Description,
                Name = source.Name,
                IsEnabled = source.IsEnabled,
                IsConfigured = source.IsConfigured,
                IsSelected = false,
                IsElectioService = source.Source == MpdCarrierServiceSource.Internal,
                CarrierAccountOwner = source.CarrierAccountOwner,
                CollectionType = source.Journey.FirstOrDefault()?.CollectionType.ToString(),
                MaintainCosts = source.MaintainCosts
            };
        }

        private static CarrierServiceViewModel MapCarrierServiceViewModel(MpdCarrierService source)
        {
            return new CarrierServiceViewModel()
            {
                Reference = source.Reference,

                CarrierName = source.CarrierName,
                CarrierReference = source.MpdCarrierReference,
                Description = source.Description,
                Name = source.Name,
                IsEnabled = true,
                IsSelected = false,
                IsElectioService = source.Source == MpdCarrierServiceSource.Internal,
                CarrierAccountOwner = source.CarrierAccountOwner,
                CollectionType = source.Journey.FirstOrDefault()?.CollectionType.ToString(),
                MaintainCosts = source.MaintainCosts
            };
        }

        private static List<LocationRestrictionViewModel> MapLocationRestrictions(MpdCarrierServiceProfile profile)
        {
            var locationRestrictions =
                profile.DomesticLocationRestrictions.Select(domesticRestriction => new LocationRestrictionViewModel
                {
                    PostcodeArea = domesticRestriction.PostcodeArea,
                    PostcodeDistrict = domesticRestriction.PostcodeDistrict,
                    PostcodeSector = domesticRestriction.PostcodeSector,
                    PostcodeUnit = domesticRestriction.PostcodeUnit
                }).ToList();

            locationRestrictions.AddRange(
                profile.InternationalLocationRestrictions.Select(intRestriction => new LocationRestrictionViewModel
                {
                    CountryIsoCode = intRestriction.CountryTwoLetterIsoCode,
                    LocationRestrictionId = intRestriction.Id
                }));

            return locationRestrictions;
        }

        private static PermissionRestrictionsViewModel PermissionRestrictionToViewModel(
            IList<Permission> permissions)
        {
            var viewModel = new PermissionRestrictionsViewModel
            {
                Groups = permissions.Select(MapPermissionViewModel).ToList()
            };
            return viewModel;
        }

        private static PermissionGroupViewModel MapPermissionViewModel(Permission permission)
        {
            return new PermissionGroupViewModel()
            {
                IsEditable = false,
                Key = permission.Key,
                Name = permission.Name,
                Permissions = new List<PermissionViewModel>()
            };
        }
    }

    public class ConsignmentStateSummaryResolver :
        IValueResolver
            <ConsignmentStateSummaryResponse, StatusSummaryResponseModel, Dictionary<ConsignmentState, int>>
    {
        public Dictionary<ConsignmentState, int> Resolve(ConsignmentStateSummaryResponse source, StatusSummaryResponseModel destination, Dictionary<ConsignmentState, int> destMember,
            ResolutionContext context)
        {
            var result = source.Summary.ToDictionary(summary => (ConsignmentState)Enum.Parse(typeof(ConsignmentState), summary.Key), summary => summary.Value);
            return result;
        }
    }

    public class ElectioConsignmentCostSummaryDestinationAddressResolver : IValueResolver<ConsignmentCostSummary, ConsignmentCostSummaryViewModel, string>
    {
        public string Resolve(ConsignmentCostSummary source, ConsignmentCostSummaryViewModel destination, string destMember,
            ResolutionContext context)
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
}