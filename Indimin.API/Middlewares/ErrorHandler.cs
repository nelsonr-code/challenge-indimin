using System.Text.Json;
using Indimin.Application.Helpers;

namespace Indimin.API.Middlewares;

public class ErrorHandler
{
    private readonly  RequestDelegate _next;
    
    public ErrorHandler(RequestDelegate next)
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
            var response = context.Response;
            response.ContentType = "application/json";
            var responseFormat = new ResponseFormatting<string>() { Message = ex.Message, Success = false };

            switch (ex)
            {
                case KeyNotFoundException _:
                    response.StatusCode = StatusCodes.Status404NotFound;
                    break;
                case Application.Exceptions.ValidationException e:
                    response.StatusCode = StatusCodes.Status400BadRequest;
                    responseFormat.Errors = e.Errors;
                    break;
                default:
                    response.StatusCode = StatusCodes.Status500InternalServerError;
                    break;
            }

            var requestResult = JsonSerializer.Serialize(responseFormat);

            await response.WriteAsync(requestResult);
        }
    }
}