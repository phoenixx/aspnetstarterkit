using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Api;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Interfaces;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security.Context;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security.Internal;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security.Nancy.v1_1;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Caching;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Caching.CacheProviders.Redis;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Caching.Managers;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Caching.Managers.Interfaces;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Logging;
using MPD.Core.Infrastructure.NetCore.Interfaces;
using MPD.Electio.SDK.NetCore;
using MPD.Electio.SDK.NetCore.Interfaces;
using MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services;
using MPD.Electio.SDK.NetCore.Internal.Interfaces;
using MPD.Electio.SDK.NetCore.Internal.Services;
using MPD.Electio.SDK.NetCore.Services.v1_1;
using Spa.StarterKit.React.Config;
using Spa.StarterKit.React.Config.Mapping;
using StructureMap;
using StructureMap.Pipeline;
using ConsignmentService = MPD.Electio.SDK.NetCore.Services.v1_1.ConsignmentService;
using IConsignmentService = MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services.IConsignmentService;
using ILogger = MPD.Electio.SDK.NetCore.Interfaces.ILogger;
using System.Linq;

namespace Spa.StarterKit.React.Ioc
{
    public class SdkRegistry
    {
        public IServiceProvider ConfigureSdkRegistry(IServiceCollection services)
        {
            var registry = new Registry();
            registry.IncludeRegistry<WebRegistry>();
            var container = new Container(registry);
            var configuration = ConfigureElectioSettings();

            container.Configure(c =>
            {
                //want this first so it is available for subsequent registrations
                //for getting current user, context etc
                //see http://stackoverflow.com/questions/36641338/how-get-current-user-in-asp-net-core
                c.For<IHttpContextAccessor>().Use<HttpContextAccessor>().LifecycleIs<SingletonLifecycle>();
            });

            container.Configure(config =>
            {
                config.Scan(c =>
                {
                    c.AssemblyContainingType(typeof(Startup));
                    c.WithDefaultConventions();
                });

                config.For<ILogger>().Use<SdkReferenceLogger>().LifecycleIs<SingletonLifecycle>();
                config.For<MPD.Core.Infrastructure.NetCore.Interfaces.ILogger>()
                    .Use<MPD.Core.Infrastructure.NetCore.Infrastructure.Logging.NLogLogger>()
                    .LifecycleIs<SingletonLifecycle>();
                config.For<IUserMetadata>()
                    .Use<UserMetadata>()
                    .LifecycleIs<TransientLifecycle>();
                config
                    .For<IContextFactory<MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security.Context.IContext>>()
                    .Use<RequestContextFactory>()
                    .LifecycleIs<TransientLifecycle>();
                //For<Application>().Use<Application>().LifecycleIs<SingletonLifecycle>();
                config.For<IConfiguration>().Use(ctx => configuration).LifecycleIs<SingletonLifecycle>();
                //config.For<IEndpoints>().Use<EndpointsFromConfiguration>().LifecycleIs<SingletonLifecycle>();
                config.For<IEndpoints>().Use<Endpoints>().LifecycleIs<SingletonLifecycle>();
                //config.For<IEndpoints>().Use(Production.Instance).LifecycleIs<SingletonLifecycle>();
                config.For<MPD.Electio.SDK.NetCore.Internal.Interfaces.IConsignmentService>()
                    .Use<MPD.Electio.SDK.NetCore.Internal.Services.ConsignmentService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<IConsignmentAllocationService>()
                    .Use<ConsignmentAllocationService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<MPD.Electio.SDK.NetCore.Interfaces.Services.IConsignmentAllocationService>()
                    .Use<MPD.Electio.SDK.NetCore.Services.ConsignmentAllocationService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<IConsignmentService>()
                    .Use<ConsignmentService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<IPackageSizeService>()
                    .Use<PackageSizeService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<IPackagesService>()
                    .Use<PackagesService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<IItemsService>()
                    .Use<ItemsService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<IShippingLocationsService>()
                    .Use<ShippingLocationsServiceService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();
                config.For<MPD.Electio.SDK.NetCore.Interfaces.Services.IShippingLocationsService>()
                    .Use<MPD.Electio.SDK.NetCore.Services.ShippingLocationsServiceService>()
                    .Ctor<Func<string>>("apiKey").Is(() => ApiKey(container))
                    .LifecycleIs<TransientLifecycle>();


                config.For<AutoMapper.IMapper>()
                    .Use(() => ConfigureMappings.ConfigureMaps())
                    .LifecycleIs<SingletonLifecycle>();

                config
                    .For<IAuthenticationService>()
                    .Use<AuthenticationService>()
                    .LifecycleIs<TransientLifecycle>();

                config
                    .For<IInternalServiceTokenService>()
                    .Use<InternalJwtTokenService>();

                config
                    .For<IInternalServiceTokenConfiguration>()
                    .Use<InternalServiceTokenConfiguration>();

                config
                    .For<ISystemLogger>()
                    .Use<NLogSystemLogger>();

                config
                    .For<IMpdStatelessAuthentication>()
                    .Use<MpdStatelessAuthentication>()
                    .LifecycleIs<TransientLifecycle>();

                config
                    .For<MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security.Nancy.IMpdStatelessAuthentication>()
                    .Use<MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security.Nancy.MpdStatelessAuthentication>()
                    .LifecycleIs<TransientLifecycle>();

                config
                    .For<ISecurityTokenCacheManager>()
                    .Use<SecurityTokenCacheManager>()
                    .LifecycleIs<TransientLifecycle>();

                config
                    .For<ICacheProvider>()
                    .Use(new RedisCacheProvider(RedisCacheConnector.Connection, new NLogSystemLogger()));

                config
                    .For<IMpdSecurityConfigSettings>()
                    .Use<MpdSecurityConfigSettings>()
                    .LifecycleIs<SingletonLifecycle>();
                //add existing service collection
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        private static IConfiguration ConfigureElectioSettings()
        {
            var environment = Environment.GetEnvironmentVariable("Environment");

            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            builder.AddJsonFile($"appsettings.{environment}.json", optional: true);
            return builder.Build();
        }

        private static string GetApiKey(IConfiguration configuration)
        {
            var electioConfig = configuration.GetSection("Electio").GetSection("ApiKey");
            return electioConfig.Value;
        }

        private string ApiKey(IContainer container)
        {
            try
            {
                var contextAccessor = container.GetInstance<IHttpContextAccessor>();
                var authToken = contextAccessor.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "AuthToken");
                return authToken == null ? "anonymous" : authToken.Value;
            }
            catch (Exception)
            {
                return "anonymous";
            }
        }
    }
}
