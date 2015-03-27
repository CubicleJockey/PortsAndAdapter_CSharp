using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PortsAndAdapters.InternalApi.Startup))]

namespace PortsAndAdapters.InternalApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
