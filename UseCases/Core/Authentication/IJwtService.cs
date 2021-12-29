using Domain.Identity.Authentication;

namespace UseCases.Core.Authentication
{
    public interface IJwtService
    {
        string CreateToken(ApplicationUser user);
    }
}