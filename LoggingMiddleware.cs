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
    public class LoggingMiddleware : OwinMiddleware
    {
        private readonly LoggingOptions options;

        public LoggingMiddleware(OwinMiddleware next, LoggingOptions options) : base(next)
        {
            this.options = options; 
        }

        public async override Task Invoke(IOwinContext context)
        {
            Console.WriteLine($"{options.Tag} : {context.Request.Path}");
            context.Request.SetSData(context.Request.Path.Value);
            await Next.Invoke(context);
            
        }
    }

    internal static class LoggingMiddlewareHandler
    {
        public static IAppBuilder UseLoggingMiddleware(this IAppBuilder app, LoggingOptions options)
        {
            app.Use<LoggingMiddleware>(options);
            return app;
        }
    }

    public sealed class LoggingOptions
    {
        public string Tag { get; set; }
    }
}
