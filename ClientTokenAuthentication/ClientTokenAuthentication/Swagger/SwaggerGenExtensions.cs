using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ClientTokenAuthentication.Swagger
{
    public static class SwaggerGenExtensions
    {
        /// <summary>
        /// Adds client/token security definitions to swagger documents.
        /// </summary>
        /// <param name="options"></param>
        public static void AddClientTokenSecurityDefinitions(this SwaggerGenOptions options)
        {
            options.AddSecurityDefinition("Client-ID", new OpenApiSecurityScheme
            {
                Description = "Required for api authentication.",
                In = ParameterLocation.Header,
                Name = AuthenticationHeaderOptions.ClientId,
                Type = SecuritySchemeType.ApiKey
            });
            options.AddSecurityDefinition(AuthenticationHeaderOptions.ApiKey, new OpenApiSecurityScheme
            {
                Description = "Required for api authentication.",
                In = ParameterLocation.Header,
                Name = AuthenticationHeaderOptions.ApiKey,
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SwaggerClientTokenHeaderFilter>();
        }
    }
}