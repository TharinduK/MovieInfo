using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MovieInfo.API.Startup))]

namespace MovieInfo.API
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseWebApi(WebApiConfig.Register());
            //ConfigureAuth(app);
        }
    }
}

