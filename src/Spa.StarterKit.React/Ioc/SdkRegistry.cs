using System;
using System.IO;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Api.Security.Internal;
using MPD.Core.Infrastructure.NetCore.Infrastructure.Logging;
using MPD.Core.Infrastructure.NetCore.Interfaces;
using MPD.Electio.SDK.NetCore;
using MPD.Electio.SDK.NetCore.Endpoints;
using MPD.Electio.SDK.NetCore.Interfaces;
using MPD.Electio.SDK.NetCore.Internal.Endpoints;
using MPD.Electio.SDK.NetCore.Internal.Interfaces;
using MPD.Electio.SDK.NetCore.Internal.Services;
using StructureMap;
using StructureMap.Pipeline;
using ConsignmentService = MPD.Electio.SDK.NetCore.Services.v1_1.ConsignmentService;
using IConsignmentService = MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services.IConsignmentService;
using ILogger = MPD.Electio.SDK.NetCore.Interfaces.ILogger;

namespace Spa.StarterKit.React.Ioc
{
    public class SdkRegistry 
    {
        public IServiceProvider ConfigureSdkRegistry(IServiceCollection services)
        {
            var container = new Container();
            var configuration = ConfigureElectioSettings();
            var apiKey = GetApiKey(configuration);

            container.Configure(config =>
            {
                config.Scan(c =>
                {
                    c.AssemblyContainingType(typeof(Startup));
                    c.WithDefaultConventions();
                });

                config.For<ILogger>().Use<SdkReferenceLogger>().LifecycleIs<SingletonLifecycle>();
                //For<Application>().Use<Application>().LifecycleIs<SingletonLifecycle>();
                config.For<IConfiguration>().Use(ctx => configuration).LifecycleIs<SingletonLifecycle>();
                config.For<IEndpoints>().Use<EndpointsFromConfiguration>().LifecycleIs<SingletonLifecycle>();
                //config.For<IEndpoints>().Use(Production.Instance).LifecycleIs<SingletonLifecycle>();
                config.For<IConsignmentService>().Use<ConsignmentService>().Ctor<string>("apiKey").Is(apiKey);

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

                //add existing service collection
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        } 

        private static IConfiguration ConfigureElectioSettings()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            return builder.Build();
        }

        private static string GetApiKey(IConfiguration configuration)
        {
            var electioConfig = configuration.GetSection("Electio").GetSection("ApiKey");
            return electioConfig.Value;
        }
    }
}
