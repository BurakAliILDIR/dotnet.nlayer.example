using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using NLayer.Core.DTO;
using NLayer.Service.Exception;

namespace NLayer.API.Middleware
{
    public static class UseCustomExceptionHandler
    {
        // IApplicationBuilder interface için bir extension method yazıcam ismi de UseCustomException.
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                // Run methodundan sonra bu middlewareden sonra olay devam etmez. Run çalışır ve biter.
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };

                    context.Response.StatusCode = statusCode;

                    var response = CustomResponseDTO<string>.Error(statusCode,exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}