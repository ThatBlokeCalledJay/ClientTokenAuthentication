using System.Threading.Tasks;

namespace ClientTokenAuthentication
{
    public interface ITokenUserStore
    {
        Task<TokenUser> TryGetTokenUserAsync(string clientId, string token);
    }
}