using Domain.Identity.Authentication;

namespace UseCases.Core.Authentication
{
    public interface IJwtService
    {
        JWT CreateToken(ApplicationUser user);
    }
}