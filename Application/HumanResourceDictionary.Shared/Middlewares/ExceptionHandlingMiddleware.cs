using System.Net;
using FluentValidation;
using HumanResourceDictionary.Shared.Models.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HumanResourceDictionary.Shared.Middlewares;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
    {
        try
        {
            await next(context);
        }
        catch (ArgumentException ex)
        {
            await HandleExceptionAsync(context, ex, (int)HttpStatusCode.BadRequest, serviceProvider);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, (int)HttpStatusCode.InternalServerError, serviceProvider);
        }
    }

    private static async Task HandleExceptionAsync(HttpContext context, Exception ex, int statusCode,
        IServiceProvider serviceProvider)
    {
        context.Response.StatusCode = statusCode;
        context.Response.ContentType = "application/json";

        var errorResponse = ActionResultResponse<object>.ErrorResult(ex.Message);

        var jsonErrorResponse = JsonConvert.SerializeObject(errorResponse);

        await context.Response.WriteAsync(jsonErrorResponse);
    }
}