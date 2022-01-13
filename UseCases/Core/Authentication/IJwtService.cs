using Domain.Identity.Authentication;
using System.Threading.Tasks;

namespace UseCases.Core.Authentication
{
    public interface IJwtService
    {
        Task<JWT> CreateToken(ApplicationUser user);
    }
}