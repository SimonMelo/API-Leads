using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Leads.API.Extensions
{
    public static class ApplicationExtensions
    {
        private const string APIKEYNAME = "X-API-KEY";

        public static IApplicationBuilder UseApiKeyMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiKeyMiddleware>();
        }

        private class ApiKeyMiddleware
        {
            private readonly RequestDelegate _next;

            public ApiKeyMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task InvokeAsync(HttpContext context)
            {
                var config = context.RequestServices.GetService(typeof(IConfiguration)) as IConfiguration 
                    ?? throw new Exception("Not Found Config");

                if (!context.Request.Headers.TryGetValue(APIKEYNAME, out var extractedApiKey))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("API Key was not provided.");
                    return;
                }

                var apiKey = config.GetValue<string>("ApiKey") ?? throw new Exception("Not Found ApiKey");

                if (!apiKey.Equals(extractedApiKey) )
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Unauthorized client.");
                    return;
                }

                await _next(context);
            }
        }

        public static WebApplication UseProjectConfiguration(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseCors("AllowAll");

            app.UseHttpsRedirection();

            app.UseApiKeyMiddleware();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapHealthChecks("/health");

            app.MapControllers();

            return app;
        }
    }
}
