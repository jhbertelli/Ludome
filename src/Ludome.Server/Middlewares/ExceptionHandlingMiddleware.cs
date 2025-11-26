using Ludome.Domain.Exceptions;
using System.Net;

namespace Ludome.Application.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                _logger.LogError(ex, $"{errorId} : {ex.Message}");

                context.Response.ContentType = "application/json";

                context.Response.StatusCode = ex switch
                {
                    UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                    BadUserRequestException => (int)HttpStatusCode.BadRequest,
                    _ => (int)HttpStatusCode.InternalServerError
                };

                var error = new
                {
                    Id = errorId,
                    ErrorMessage = context.Response.StatusCode is (int)HttpStatusCode.InternalServerError
                        ? "Algo deu errado!"
                        : ex.Message
                };

                await context.Response.WriteAsJsonAsync(error);
            }
        }
    }
}