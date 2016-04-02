using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OWINTest
{
    public class TeapotMiddleware : OwinMiddleware
    {
        private readonly TeapotOptions options;
        public TeapotMiddleware(OwinMiddleware next, TeapotOptions options) : base(next)
        {
            this.options = options;
        }

        public async override Task Invoke(IOwinContext context)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, "Scott"));
            claims.Add(new Claim(ClaimTypes.Email, "scott@scottbrady91.com"));

            var id = new ClaimsIdentity(claims, "cookie");
            context.Authentication.SignIn(id);


            context.Response.StatusCode = 418;
            context.Response.ContentType = "image/jpeg";
            
            bool sendingfile = context.Response.SupportsSendFile();
            try
            {
                await context.Response.SendFileAsync("img/teapot.jpg");
            }
            catch(Exception exception)
            {
                context.Response.ContentType = "text/html";
                context.Response.Write("<h2>ouch something bad happened : " + exception.Message+"</h2><p>"+exception.StackTrace.Replace("\n","<br>")+"</p>");
                
            }
            
        }
    }

    internal static class TeapotMiddlewareHandler
    {
        public static IAppBuilder UseTeapotMiddleware(this IAppBuilder app, TeapotOptions options)
        {
            app.Use<TeapotMiddleware>(options);
            return app;
        }
    }

    public sealed class TeapotOptions
    {
        public string Biscuit { get; set; }
    }
}
