using System;
using System.Threading.Tasks;
using QuickTour.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace QuickTour.Middleware
{
    public class CustomMiddleware2
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware2> _logger;

        public CustomMiddleware2(RequestDelegate next, ILogger<CustomMiddleware2> logger)
        {
            _next = next;
            _logger = logger;
            _logger.LogWarning("Middleware2 created");
        }

        public async Task InvokeAsync(HttpContext context, ITransient tran, IScoped scoped, ISingleton single)
        {
            _logger.LogWarning("Middleware2 Invoked");
            tran.WriteGuidToConsole();
            scoped.WriteGuidToConsole();
            single.WriteGuidToConsole();

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
