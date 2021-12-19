using UseCases.Core.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Identity.Authentication;
using UseCases.Core;

namespace UseCases.Authentication
{
    public class Login
    {
        public class Query : IRequest<UserDto>
        {
            public LoginModel LoginModel { get; set; }
        }
        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly IJwtService _jwtService;
            private readonly UserManager<ApplicationUser> userManager;

            public Handler(IJwtService jwtService, UserManager<ApplicationUser> userManager)
            {
                _jwtService = jwtService;
                this.userManager = userManager;
            }

            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await userManager.FindByNameAsync(request.LoginModel.Username);
                if (user == null)
                {
                    return null;
                }

                string token = _jwtService.CreateToken(user);
                return new UserDto { Token = token, UserName = user.UserName };
            }
        }
    }
}
