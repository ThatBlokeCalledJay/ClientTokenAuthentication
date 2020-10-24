using Microsoft.Extensions.DependencyInjection;

namespace ClientTokenAuthentication
{
    public static class ServiceExtensions
    {
        /// <summary>
        /// Add Client/Token based authentication scheme.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddClientTokenAuthenticationScheme(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = AuthenticationSchemeOptions.ClientTokenAuthenticationScheme;
            }).AddScheme<ClientTokenAuthenticationSchemeOptions, ClientTokenAuthenticationHandler>(AuthenticationSchemeOptions.ClientTokenAuthenticationScheme, o => { });

            return services;
        }
    }
}