using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace WebApplication1.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew(); 

            try
            {
                Log.Information("Handling request: {Method} {Url}", context.Request.Method, context.Request.Path);

                await _next(context);

                stopwatch.Stop();
                Log.Information("Handled request: {Method} {Url} with status code {StatusCode} in {ElapsedMilliseconds}ms",
                    context.Request.Method,
                    context.Request.Path,
                    context.Response.StatusCode,
                    stopwatch.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                Log.Error(ex, "An error occurred while processing the request.");
                throw; 
            }
        }
    }

}
