using Domain.Identity.Authentication;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core.Authentication;
using UseCases.Core.DTOs;

namespace UseCases.Authentication
{
    public class GetUser
    {
        public class Query : IRequest<UserDto>
        {
            public string Token { get; set; }
        }

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly IJwtService _jwtService;
            private readonly UserManager<ApplicationUser> _userManager;

            public Handler(IJwtService jwtService, UserManager<ApplicationUser> userManager)
            {
                _jwtService = jwtService;
                _userManager = userManager;
            }

            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var securityToken = await _jwtService.Verify(request.Token);
                var user = await _userManager.FindByNameAsync(securityToken.Claims.SingleOrDefault(claim => claim.Type == JwtRegisteredClaimNames.NameId).Value);
                return new UserDto() { UserName = user.UserName, Email = user.Email };
            }
        }
    }
}
