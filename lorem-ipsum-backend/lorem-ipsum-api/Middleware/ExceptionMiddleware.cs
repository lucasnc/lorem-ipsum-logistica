using LoremIpsum.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace lorem_ipsum_api.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;
            var errorResponse = string.Empty;

            switch (exception)
            {
                case BadRequestException ex:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse = ex.Message;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse = "Internal server error";
                    break;
            }

            var result = JsonSerializer.Serialize(new { message = errorResponse, code = response.StatusCode });
            return context.Response.WriteAsync(result);
        }
    }
}
