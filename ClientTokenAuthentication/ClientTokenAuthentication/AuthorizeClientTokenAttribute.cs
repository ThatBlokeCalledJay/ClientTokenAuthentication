using Microsoft.AspNetCore.Authorization;

namespace ClientTokenAuthentication
{
    /// <summary>
    /// Implementation of the <seealso cref="AuthorizeAttribute"/> using the ClientTokenAuthenticationScheme scheme.
    /// </summary>
    public class AuthorizeClientTokenAttribute : AuthorizeAttribute
    {
        public AuthorizeClientTokenAttribute()
        {
            AuthenticationSchemes = AuthenticationSchemeOptions.ClientTokenAuthenticationScheme;
        }
    }
}