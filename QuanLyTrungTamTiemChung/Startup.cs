using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyTrungTamTiemChung.Startup))]
namespace QuanLyTrungTamTiemChung
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
