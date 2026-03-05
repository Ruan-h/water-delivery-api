using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WaterDelivery.Domain.Validation;

namespace WaterDelivery.API.Middlewares;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Ocorreu uma exceção: {Message}", exception.Message);

        var problemDetails = new ProblemDetails
        {
            Instance = httpContext.Request.Path
        };

        if (exception is DomainExceptionValidation domainEx)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            problemDetails.Title = "Erro de Regra de Negócio";
            problemDetails.Status = StatusCodes.Status400BadRequest;
            problemDetails.Detail = domainEx.Message;
        }
        else if (exception is ValidationException validationEx)
        {

            httpContext.Response.StatusCode = StatusCodes.Status422UnprocessableEntity;
            problemDetails.Title = "Erro de Validação dos Dados";
            problemDetails.Status = StatusCodes.Status422UnprocessableEntity;
            
            var errors = validationEx.Errors
                .GroupBy(x => x.PropertyName)
                .ToDictionary(
                    g => g.Key, 
                    g => g.Select(x => x.ErrorMessage).ToArray()
                );
                
            problemDetails.Extensions.Add("errors", errors);
        }
        else
        {
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            problemDetails.Title = "Erro Interno do Servidor";
            problemDetails.Status = StatusCodes.Status500InternalServerError;
            problemDetails.Detail = "Ocorreu um erro inesperado. Por favor, contate o suporte.";
        }

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true; 
    }
}