using AutoMapper;
using MPD.Electio.SDK.NetCore.Internal.Mapping;
using Spa.StarterKit.React.Config.Mapping.Profiles.ServiceInterfaceToViewModel;

namespace Spa.StarterKit.React.Config.Mapping
{
    public static class ConfigureMappings
    {
        private static IMapper _mapper;

        public static IMapper ConfigureMaps()
        {
            if (_mapper != null)
            {
                return _mapper;
            }

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ConsignmentsProfile>();
                //cfg.AddProfile<SdkToCoreLibMaps>();
                //cfg.AddProfile<CoreLibToSdkMaps>();
            });
            mapperConfig.AssertConfigurationIsValid();
            _mapper = mapperConfig.CreateMapper();
            return _mapper;
        }

        //private static void Conf(IMapperConfigurationExpression expr)
        //{
        //    expr.AddProfile<SdkToCoreLibMaps>();
        //    expr.AddProfile<CoreLibToSdkMaps>();
        //}
        //private static void Configure(IConfiguration mapperConfiguration)
        //{
        //    mapperConfiguration.Profiles.Append(new SdkToCoreLibMaps());
        //    mapperConfiguration.Profiles.Append(new CoreLibToSdkMaps());
        //    //mapperConfiguration.AddProfile<SdkToCoreLibMaps>();
        //    //mapperConfiguration.AddProfile<CoreLibToSdkMaps>();
        //    //mapperConfiguration.AddProfile<DomainModelToViewModelMaps>();
        //    //mapperConfiguration.AddProfile<ViewModelToDomainModelMaps>();
        //    //mapperConfiguration.AddProfile<ContractToModelMaps>();
        //    //mapperConfiguration.AddProfile<ModelToContractMaps>();
        //    //mapperConfiguration.AddProfile<ServiceInterfaceToViewModelMaps>();
        //    //mapperConfiguration.AddProfile<ViewModelToServiceInterfaceMaps>();
        //    //mapperConfiguration.AddProfile<InternalMaps>();
        //    //mapperConfiguration.AddProfile<ZendeskMaps>();

        //    ServiceInterfaceToViewModelMaps(mapperConfiguration);
        //    ViewModelToServiceInterfaceMaps(mapperConfiguration);
        //}

        //private static void ServiceInterfaceToViewModelMaps(IConfiguration mapperConfiguration)
        //{
        //    //mapperConfiguration.AddProfile<SubscriptionServiceInterfaceToViewModel>();
        //    //mapperConfiguration.AddProfile<ConsignmentServiceInterfaceToViewModel>();
        //    //mapperConfiguration.AddProfile<PaymentServiceInterfaceToViewModel>();
        //    //mapperConfiguration.AddProfile<RatesServiceInterfaceToViewModelProfile>();
        //    //mapperConfiguration.AddProfile<ReportsInterfaceToViewModel>();
        //}

        //private static void ViewModelToServiceInterfaceMaps(IConfiguration mapperConfiguration)
        //{
        //    //mapperConfiguration.AddProfile<ConsignmentViewModelsToServiceInterface>();
        //    //mapperConfiguration.AddProfile<ViewModelToPaymentServiceMaps>();
        //    //mapperConfiguration.AddProfile<ViewModelToRatesServiceMaps>();
        //    //mapperConfiguration.AddProfile<ReportsViewModelToInterface>();
        //}
    }
}