using HawksNestGolf.NET.Shared.Models;
using System.Text.Json;

namespace HawksNestGolf.NET.Server.Middleware
{
    public static class CustomExceptionHandlerExtension
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandler>();
        }
    }

    public class CustomExceptionHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomExceptionHandler> _logger;

        public CustomExceptionHandler(RequestDelegate next,
            ILogger<CustomExceptionHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Call the next delegate/middleware in the pipeline.
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;

                var errorDetails = new ResponseErrorDetails
                {
                    StatusCode = 500,
                    Details = ex.Message,
                    TraceId = context.TraceIdentifier,
                    UserName = context.User.Identity?.Name ?? ""
                };
                _logger.LogError("Server Error {details}", JsonSerializer.Serialize(errorDetails));
                await context.Response.WriteAsJsonAsync<ResponseErrorDetails>(errorDetails);
            }
        }

    }
}
