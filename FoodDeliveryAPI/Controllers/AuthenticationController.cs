using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Authentication;
using UseCases.Core.Authentication;
using UseCases.Core.DTOs;

namespace FoodDeliveryAPI.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            UserDto res = await Mediator.Send(new Login.Query { LoginModel = model });
            return res == null ? Unauthorized() : Ok(res);
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            RegisterResponse res = await Mediator.Send(new Register.Command { RegisterModel = model });
            return res.Status == "Error" ? StatusCode(StatusCodes.Status500InternalServerError, res) : Ok(res);
        }

        [HttpPost]
        [Route("registerAdmin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            RegisterResponse res = await Mediator.Send(new RegisterAdmin.Command { RegisterModel = model });
            return res.Status == "Error" ? StatusCode(StatusCodes.Status500InternalServerError, res) : Ok(res);
        }
    }
}
