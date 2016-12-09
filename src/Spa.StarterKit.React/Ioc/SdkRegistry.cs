using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MPD.Electio.SDK.NetCore;
using MPD.Electio.SDK.NetCore.Endpoints;
using MPD.Electio.SDK.NetCore.Interfaces;
using MPD.Electio.SDK.NetCore.Interfaces.v1_1.Services;
using MPD.Electio.SDK.NetCore.Services.v1_1;
using StructureMap;
using StructureMap.Pipeline;

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
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Startup));
                    _.WithDefaultConventions();
                });

                config.For<ILogger>().Use<SdkReferenceLogger>().LifecycleIs<SingletonLifecycle>();
                //For<Application>().Use<Application>().LifecycleIs<SingletonLifecycle>();
                config.For<IConfiguration>().Use(ctx => configuration).LifecycleIs<SingletonLifecycle>();
                config.For<IEndpoints>().Use(Production.Instance).LifecycleIs<SingletonLifecycle>();
                config.For<IConsignmentService>().Use<ConsignmentService>().Ctor<string>("apiKey").Is(apiKey);

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
