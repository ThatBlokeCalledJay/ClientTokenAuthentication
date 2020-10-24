using ClientTokenAuthentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExampleAPI3x
{
    /// <inheritdoc />
    public class DummyTokenUserStore : ITokenUserStore
    {
        private static readonly Dictionary<string, TokenUser> TempUsers =
            new Dictionary<string, TokenUser>
            {
                {
                    "client-id-token", new TokenUser {ClientId = "client-id"}
                }
            };

        /// <inheritdoc />
        public async Task<TokenUser> TryGetTokenUserAsync(string clientId, string token)
        {
            return TempUsers.TryGetValue($"{clientId}-{token}", out var tokenUser) ? tokenUser : (TokenUser)null;
        }
    }
}