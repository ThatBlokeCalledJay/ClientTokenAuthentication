using System.Collections.Generic;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ClientTokenAuthentication
{
    public class ClientTokenAuthenticationSchemaOptions : Microsoft.AspNetCore.Authentication.AuthenticationSchemeOptions { }

    /// <inheritdoc />
    public class ClientTokenAuthenticationHandler : AuthenticationHandler<ClientTokenAuthenticationSchemaOptions>
    {
        private readonly ITokenUserStore _tokenUserStore;

        public ClientTokenAuthenticationHandler(
            IOptionsMonitor<ClientTokenAuthenticationSchemaOptions> options,
            ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ITokenUserStore tokenUserStore)
            : base(options, logger, encoder, clock)
        {
            _tokenUserStore = tokenUserStore;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue(AuthenticationHeaderOptions.ApiKey, out var tokenStringValue))
                return AuthenticateResult.Fail("Required Header Missing");

            if (!Request.Headers.TryGetValue(AuthenticationHeaderOptions.ClientId, out var idStringValues))
                return AuthenticateResult.Fail("Required Header Missing");

            var clientToken = tokenStringValue.ToString();
            var clientId = idStringValues.ToString();

            var tokenUser = await _tokenUserStore.TryGetTokenUserAsync(clientId, clientToken);

            if (tokenUser == null)
                return AuthenticateResult.Fail("Invalid Client Id or Client Token");

            var claims = new List<Claim>
            {
                new Claim(ClientTokenClaimOptions.ClientId, tokenUser.ClientId)
            };

            var claimsIdentity = new ClaimsIdentity(claims, nameof(ClientTokenAuthenticationHandler));

            var ticket = new AuthenticationTicket(new ClaimsPrincipal(claimsIdentity), Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}