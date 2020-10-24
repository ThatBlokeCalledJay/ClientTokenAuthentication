using Microsoft.Extensions.DependencyInjection;

namespace ClientTokenAuthentication
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add Client/Token based authentication schema.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddClientTokenAuthenticationSchema(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = AuthenticationSchemaOptions.ClientTokenAuthenticationSchema;
            }).AddScheme<ClientTokenAuthenticationSchemaOptions, ClientTokenAuthenticationHandler>(AuthenticationSchemaOptions.ClientTokenAuthenticationSchema, o => { });

            return services;
        }
    }
}