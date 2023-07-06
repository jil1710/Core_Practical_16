using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Core_Practical_16
{
   
    public class MyLoggerMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MyLoggerMiddleWare> _logger;

        public MyLoggerMiddleWare(RequestDelegate next, ILogger<MyLoggerMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        public Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Hello World API Print From End Point : " + httpContext.Request.Path);
            _logger.LogInformation("Hello World API Request Method : " + httpContext.Request.Method);
            _logger.LogInformation("Hello World API Request Host Name : " + httpContext.Request.Host);
            _logger.LogInformation("Hello World API Request is Https( Use SSL ) ? : " + httpContext.Request.IsHttps);
            _logger.LogInformation("Hello World API Request Protocol : " + httpContext.Request.Protocol);
            return _next(httpContext);
        }
    }

    
    public static class MyLoggerMiddleWareExtensions
    {
        public static IApplicationBuilder UseMyLoggerMiddleWare(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyLoggerMiddleWare>();
        }
    }
}
