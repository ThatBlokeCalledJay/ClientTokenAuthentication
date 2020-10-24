using Microsoft.AspNetCore.Authorization;

namespace ClientTokenAuthentication
{
    /// <summary>
    /// Implementation of the <seealso cref="AuthorizeAttribute"/> using the ClientTokenAuthenticationSchema schema.
    /// </summary>
    public class AuthorizeClientTokenAttribute : AuthorizeAttribute
    {
        public AuthorizeClientTokenAttribute()
        {
            AuthenticationSchemes = AuthenticationSchemaOptions.ClientTokenAuthenticationSchema;
        }
    }
}