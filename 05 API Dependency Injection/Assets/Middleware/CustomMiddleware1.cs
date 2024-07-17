using System;
using System.Threading.Tasks;
using QuickTour.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace QuickTour.Middleware
{
    public class CustomMiddleware1
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware1> _logger;

        public CustomMiddleware1(RequestDelegate next, ILogger<CustomMiddleware1> logger)
        {
            _next = next;
            _logger = logger;
            _logger.LogWarning("Middleware1 created");
        }

        public async Task InvokeAsync(HttpContext context, ITransient tran, IScoped scoped, ISingleton single)
        {
            _logger.LogWarning("Middleware1 Invoked");
            tran.WriteGuidToConsole();
            scoped.WriteGuidToConsole();
            single.WriteGuidToConsole();

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }
}
