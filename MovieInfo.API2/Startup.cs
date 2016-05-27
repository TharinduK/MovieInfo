using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

[assembly: OwinStartup(typeof(MovieInfo.API2.Startup))]
namespace MovieInfo.API2
{

    public class Startup
    {
        public void Configuration(IAppBuilder app )
        {
            app.UseWebApi(WebApiConfig.Register());
        }
    }
}
