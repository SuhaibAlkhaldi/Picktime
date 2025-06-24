using System.Security.Claims;

namespace Picktime.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(IEnumerable<Claim> claims);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
