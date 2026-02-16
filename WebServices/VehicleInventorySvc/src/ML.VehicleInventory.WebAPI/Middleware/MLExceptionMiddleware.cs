using System.Net;
using VehicleInventory.Domain.Exceptions;

namespace ML.VehicleInventory.WebAPI.Middleware
{
    public class MLExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MLExceptionMiddleware> _logger;

        public MLExceptionMiddleware(RequestDelegate next, ILogger<MLExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DomainException ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception");

                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await context.Response.WriteAsJsonAsync(new { error = "Something went wrong." });
            }
        }
    }
}
