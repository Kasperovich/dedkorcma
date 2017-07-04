using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DedKorchma.Startup))]
namespace DedKorchma
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
