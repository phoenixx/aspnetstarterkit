using Spa.StarterKit.React.Services;
using Spa.StarterKit.React.Services.Interfaces;
using StructureMap;
using StructureMap.Pipeline;

namespace Spa.StarterKit.React.Ioc
{
    public class WebRegistry : Registry
    {
        public WebRegistry()
        {
            For<ILoginService>().Use<LoginService>().LifecycleIs<TransientLifecycle>();
        }
    }
}
