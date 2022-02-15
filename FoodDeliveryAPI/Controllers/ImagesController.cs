using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.Core.Authentication;
using UseCases.Core.DTOs;
using UseCases.Images;

namespace FoodDeliveryAPI.Controllers
{
    public class ImagesController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<GetImageDto>>> GetAllImages()
        {
            var res = await Mediator.Send(new GetAllImages.Query());
            return Ok(res);
        }

        // GET: api/index/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetImageDto>> GetImageById(int id)
        {
            var res = await Mediator.Send(new GetImage.Query());
            return Ok(res);
        }

        // POST: api/index
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddItem([FromBody] CreateImageDto item)
        {
            var res = await Mediator.Send(new AddImage.Command() { ImageDto = item });
            return Ok(res);
        }

        //DELETE: api/index/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteItem(string id)
        {
            var res = await Mediator.Send(new DeleteImage.Command() {Id = id });
            return Ok(res);
        }
    }
}
