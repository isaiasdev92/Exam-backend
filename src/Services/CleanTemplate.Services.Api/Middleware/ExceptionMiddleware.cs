using System.Net;
using CleanTemplate.Application.Core;
using CleanTemplate.Transversal.Core;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace CleanTemplate.Services.Api;


public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly IHostEnvironment _env;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger, IHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            context.Response.ContentType = "application/json";
            var statusCode = (int)HttpStatusCode.InternalServerError;
            var result = string.Empty;

            var response = new Response<object>();

            switch (ex)
            {
                case NotFoundException notFoundException:
                    statusCode = (int)HttpStatusCode.NotFound;
                    response.Message = ex.Message;
                     response.Errors = [ex.Message];                    
                    break;

                case ValidationException validationException:
                    statusCode = (int)HttpStatusCode.BadRequest;
                    var failures = validationException.Errors.SelectMany(r => r.Value).Where(f => f != null).ToList();
                    response.Message = ex.Message;
                    response.Errors = failures ?? [];
                    break;

                case BadRequestException badRequestException:
                    response.Message = ex.Message;
                     response.Errors = [ex.Message];
                    statusCode = (int)HttpStatusCode.BadRequest;
                    break;

                default:
                    statusCode = (int)HttpStatusCode.InternalServerError;
                    response.Message = ex.Message;
                     response.Errors = [ex.Message];
                    break;
            }

            var resultJson = JsonConvert.SerializeObject(response);

            context.Response.StatusCode = statusCode;

            await context.Response.WriteAsync(resultJson);

        }

    }

}
