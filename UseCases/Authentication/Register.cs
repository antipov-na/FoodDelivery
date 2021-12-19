using UseCases.Core.Authentication;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Identity.Authentication;
using System;

namespace UseCases.Authentication
{
    public class Register
    {
        public class Command : IRequest<RegisterResponse>
        {
            public RegisterModel RegisterModel { get; set; }
        }
        public class Handler : IRequestHandler<Command, RegisterResponse>
        {
            private readonly UserManager<ApplicationUser> userManager;

            public Handler(UserManager<ApplicationUser> userManager)
            {
                this.userManager = userManager;
            }

            public async Task<RegisterResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var userExists = await userManager.FindByNameAsync(request.RegisterModel.Username);
                if (userExists != null)
                    return new RegisterResponse { Status = "Error", Message = "User already exists!" };

                ApplicationUser user = new ApplicationUser()
                {
                    Email = request.RegisterModel.Email,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = request.RegisterModel.Username
                };
                var result = await userManager.CreateAsync(user, request.RegisterModel.Password);
                if (!result.Succeeded)
                    return new RegisterResponse { Status = "Error", Message = "User creation failed! Please check user details and try again." };

                return new RegisterResponse { Status = "Success", Message = "User created successfully!" };
            }
        }
    }
}
