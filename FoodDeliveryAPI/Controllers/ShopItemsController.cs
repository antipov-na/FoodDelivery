using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Domain.Entities;
using Domain.Identity;
using System.Collections.Generic;
using UseCases.FoodItems;
using UseCases.Images;
using UseCases.Core.Images;
using System.Threading.Tasks;
using UseCases.ItemTypes;
using Domain.Entities.ValueObjects;

namespace FoodDeliveryAPI.Controllers
{
    public class ShopItemsController : BaseApiController
    {
        // GET: api/index
        [HttpGet]
        public async Task<ActionResult<List<FoodItem>>> GetAll()
        {
            var res = await Mediator.Send(new GetAll.Query());
            return Ok(res);
        }

        // GET: api/index/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItem>> GetItemById(int id)
        {
            return await Mediator.Send(new GetById.Query { Id = id });
        }

        // GET: api/index/GetRange/{startId}/amount/{amount}
        [HttpGet("GetRange/{startId}/amount/{amount}")]
        public async Task<ActionResult<List<FoodItem>>> GetItemByRange(int startId, int amount)
        {
            return await Mediator.Send(new GetByRange.Query { StartId = startId, Range = amount });
        }

        // POST: api/index
        [HttpPost]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddItem([FromForm] FoodItemDTO item)
        {
            var result = await Mediator.Send(new AddImage.Command { Image = item.Image });
            var type = await Mediator.Send(new GetItemTypeById.Query { Id = item.Dto.TypeId });
            FoodItem _item = new()
            {
                Name = item.Dto.Name,
                Description = item.Dto.Description,
                Price = Price.From(item.Dto.Price),
                Type = type,
                Image = new Image() { Id = result.Id, Url = result.Url }
            };

            return Ok(await Mediator.Send(new Add.Command { FoodItem = _item }));
        }

        // PUT: api/index
        [HttpPut]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> EditItem([FromForm] FoodItemDTO item)
        {
            CloudinaryApiResult newImage = null;
            if (item.Image != null)
            {
                var shopItem = await Mediator.Send(new GetById.Query { Id = item.Dto.Id });
                await Mediator.Send(new DeleteImage.Command { Id = shopItem.Image.Id });
                newImage = await Mediator.Send(new AddImage.Command { Image = item.Image });
            }
            var type = await Mediator.Send(new GetItemTypeById.Query { Id = item.Dto.TypeId });

            FoodItem _item = new()
            {
                Id = item.Dto.Id,
                Name = item.Dto.Name,
                Image = newImage != null ? new Image() { Id = newImage.Id, Url = newImage.Url } : null,
                Description = item.Dto.Description,
                Type = type,
                Price = Price.From(item.Dto.Price),
            };

            return Ok(await Mediator.Send(new Edit.Command { FoodItem = _item }));
        }

        //DELETE: api/index/{id}
        [HttpDelete("{id}")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await Mediator.Send(new GetById.Query { Id = id });
            await Mediator.Send(new DeleteImage.Command { Id = item.Image.Id });
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
