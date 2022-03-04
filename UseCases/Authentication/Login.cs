using UseCases.Core.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Identity.Authentication;
using UseCases.Core.DTOs;

namespace UseCases.Authentication
{
    public class Login
    {
        public class Query : IRequest<Jwt>
        {
            public LoginModel LoginModel { get; set; }
        }
        public class Handler : IRequestHandler<Query, Jwt>
        {
            private readonly IJwtService _jwtService;
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(IJwtService jwtService, UserManager<ApplicationUser> userManager)
            {
                _jwtService = jwtService;
                _userManager = userManager;
            }

            public async Task<Jwt> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByNameAsync(request.LoginModel.Username);
                if (user == null || !await _userManager.CheckPasswordAsync(user, request.LoginModel.Password))
                {
                    return null;
                }

                return await _jwtService.CreateToken(user);
            }
        }
    }
}
