using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using UseCases.Core.Images;

namespace FoodDeliveryAPI.Middleware
{
    public class CustomExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public CustomExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            var code = HttpStatusCode.InternalServerError;
            var result = string.Empty;
            switch (e)
            {
                case CloudinaryUploadException uploadException:
                    code = HttpStatusCode.UnprocessableEntity;
                    result = uploadException.Message;
                    break;
                case EntityNotFoundException notFoundException:
                    code = HttpStatusCode.NotFound;
                    result = notFoundException.Message;
                    break;
            }
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            if(result == string.Empty)
            {
                result = JsonSerializer.Serialize(new { error = e.Message });
            }

            return context.Response.WriteAsync(result + e.StackTrace);
        }
    }
}
