using LoginService.Core.CustomException;
using LoginService.Models;
using Microsoft.AspNetCore.Http;

namespace MicroLogin.Middlewares
{
    public class CustomExceptionNoHeadersMiddleware(RequestDelegate _next,
                                                    ILogger<CustomExceptionNoHeadersMiddleware> _logger)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (CustomExceptionMessage ex)
            {
                CustomErrorResponse customErrorResponse = new CustomErrorResponse()
                {
                    eventItems = new List<CustomErrorItem>
                {
                    new CustomErrorItem
                        {
                            severityCode = "Error",
                            Description = ex.Message
                        }
                }
                };
                httpContext.Response.StatusCode = ex.StatusCode;
                httpContext.Response.ContentType = "application/json";
                await httpContext.Response.WriteAsJsonAsync(customErrorResponse);
            }
        }
    }
}
