using Indimin.API.Middlewares;

namespace Indimin.API;

public static class PresentationExtensions
{
    public static void UseErrorHandlerMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ErrorHandler>();
    }
}