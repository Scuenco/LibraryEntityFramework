using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibraryEntity.Startup))]
namespace LibraryEntity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
