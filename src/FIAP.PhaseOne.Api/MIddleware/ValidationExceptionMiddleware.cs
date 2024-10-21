using FIAP.PhaseOne.Api.Controllers.Shared;
using FIAP.PhaseOne.Api.Extensions;
using FluentValidation;
using Newtonsoft.Json;
using System.Net;

namespace FIAP.PhaseOne.Api.MIddleware
{
    public class ValidationExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ValidationExceptionMiddleware> _logger;

        public ValidationExceptionMiddleware(RequestDelegate next, ILogger<ValidationExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (ValidationException ex)
            {
                _logger.LogError($"Erro de validação: {ex}");
                await HandleValidationExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            var listErros = new List<string>();
            foreach (var error in exception.Errors) { 
                listErros.Add(error.ErrorMessage);
            }
            var response = new CustomResult((HttpStatusCode)context.Response.StatusCode, false, null, listErros);
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new LowercaseContractResolver()
            };
            return context.Response.WriteAsync(JsonConvert.SerializeObject(response, settings));

        }
    }
}