using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation;
using Microsoft.OpenApi.Extensions;
using TWJobs.Api.Commons.Dtos;
using TWJobs.Core.Exceptions;

namespace TWJobs.Core.Middlewares
{
    public class ExceptionHandlerMiddleware(RequestDelegate next)
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (ModelNotFoundException ex)
            {
                await HandleModelNotFoundExceptionAsync(context, ex);
            }
            catch (ValidationException ex)
            {
                await HandleValidationException(context, ex);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleValidationException(HttpContext context, ValidationException ex)
        {
            var body = new ValidationErrorResponse
            {
                Status = 400,
                Error = "Bad Request",
                Cause = ex.GetType().Name,
                Message = "Validation Error",
                Timestamp = DateTime.Now,
                Errors = ex.Errors.GroupBy(vf => vf.PropertyName)
                    .ToDictionary(g => g.Key, g => g.Select(vf => vf.ErrorMessage)
                        .ToArray())
            };
            context.Response.StatusCode = body.Status;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var body = new ErrorResponse
            {
                Status = 404,
                Error = "Not Found",
                Cause = ex.GetType().Name,
                Message = ex.Message,
                Timestamp = DateTime.Now
            };
            context.Response.StatusCode = body.Status;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }

        private Task HandleModelNotFoundExceptionAsync(HttpContext context, Exception ex)
        {
            var body = new ErrorResponse
            {
                Status = 404,
                Error = "Not Found",
                Cause = ex.GetType().Name,
                Message = ex.Message,
                Timestamp = DateTime.Now
            };
            context.Response.StatusCode = body.Status;
            context.Response.ContentType = "application/json";
            return context.Response.WriteAsync(JsonSerializer.Serialize(body, _jsonSerializerOptions));
        }
    }
}
