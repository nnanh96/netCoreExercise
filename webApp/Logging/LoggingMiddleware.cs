using System.Threading.Tasks;
using log4net;
using Microsoft.AspNetCore.Http;

namespace webApp.Logging
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        
        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
            
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var requestInfo = httpContext.Request.Path.Value;
            await httpContext.Response.WriteAsync($"logging middleware URL: {requestInfo}");
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    //public static class LoggingMiddlewareExtensions
    //{
    //    public static IApplicationBuilder UseLoggingMiddleware(this IApplicationBuilder builder)
    //    {
    //        return builder.UseMiddleware<LoggingMiddleware>();
    //    }
    //}
}
