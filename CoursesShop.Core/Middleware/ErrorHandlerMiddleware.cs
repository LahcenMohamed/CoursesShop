using CoursesShop.Core.Bases;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Text.Json;

namespace CoursesShop.Core.Middleware
{
    public sealed class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
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
                context.Response.ContentType = "application/json";
                var responseModel = new Response<string>
                {
                    Succeeded = false,
                    Message = ex.Message,
                    StatusCode = GetStatusCode(ex)
                };
                if (ex.InnerException != null)
                    responseModel.Message += "\n" + ex.InnerException.Message;

                context.Response.StatusCode = (int)responseModel.StatusCode;
                var result = JsonSerializer.Serialize(responseModel);
                await context.Response.WriteAsync(result);
            }
        }

        private HttpStatusCode GetStatusCode(Exception ex)
        {
            if (ex.GetType().ToString() == "ApiException")
                return HttpStatusCode.BadRequest;
            return ex switch
            {
                UnauthorizedAccessException _ => HttpStatusCode.Unauthorized,
                ValidationException _ => HttpStatusCode.UnprocessableEntity,
                KeyNotFoundException _ => HttpStatusCode.NotFound,
                DbUpdateException _ => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
        }
    }
}
