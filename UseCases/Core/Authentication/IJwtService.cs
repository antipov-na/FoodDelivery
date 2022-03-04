using Domain.Identity.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;

namespace UseCases.Core.Authentication
{
    public interface IJwtService
    {
        Task<Jwt> CreateToken(ApplicationUser user);
        Task<JwtSecurityToken> Verify(string token);
    }
}