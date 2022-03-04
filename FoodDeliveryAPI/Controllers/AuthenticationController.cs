using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UseCases.Authentication;
using UseCases.Core.Authentication;

namespace FoodDeliveryAPI.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var res = await Mediator.Send(new Login.Query { LoginModel = model });
            Response.Cookies.Append("jwt", res.Token, new CookieOptions() { HttpOnly = true, Expires = res.ValidTo });
            return res == null ? Unauthorized() : Ok();
        }

        [HttpPost]
        [Route("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return Ok();
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

        [HttpGet]
        [Route("user")]
        [Authorize]
        public async Task<IActionResult> User()
        {
            var res = await Mediator.Send(new GetUser.Query { Token = Request.Cookies["jwt"] });
            return Ok(res);
        }
    }
}
