using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWINTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            app.UseFileServer();
            app.UseLoggingMiddleware(new LoggingOptions { Tag = "HALO ! "});
            app.UseTeapotMiddleware(new TeapotOptions { Biscuit = "Hobnob" });
            
            
            //app.UseOrderMiddleware();
        }
    }
}
