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
using AutoMapper;

namespace FoodDeliveryAPI.Controllers
{
    public class ShopItemsController : BaseApiController
    {
        private readonly IMapper _maper;

        public ShopItemsController(IMapper mapper) 
            : base()
        {
            _maper = mapper;
        }

        // GET: api/index
        [HttpGet]
        public async Task<ActionResult<List<FoodItemDTO>>> GetAll()
        {
            var res = await Mediator.Send(new GetAll.Query());
            return Ok(_maper.Map<List<FoodItemDTO>>(res));
        }

        // GET: api/index/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FoodItemDTO>> GetItemById(int id)
        {
            var res = await Mediator.Send(new GetById.Query { Id = id });
            return Ok(_maper.Map<FoodItemDTO>(res));
        }

        // GET: api/index/GetRange/{startId}/amount/{amount}
        [HttpGet("GetRange/{startId}/amount/{amount}")]
        public async Task<ActionResult<List<FoodItemDTO>>> GetItemByRange(int startId, int amount)
        {
            var res = await Mediator.Send(new GetByRange.Query { StartId = startId, Range = amount });
            return Ok(_maper.Map<FoodItemDTO>(res));
        }

        // POST: api/index
        [HttpPost]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddItem([FromForm] FoodItemDTO item)
        {
            var imageRes = await Mediator.Send(new AddImage.Command { Image = item.Image });
            var typeRes = await Mediator.Send(new GetItemTypeById.Query { Id = item.Dto.TypeId });
            FoodItem _item = _maper.Map<FoodItem>(item);
            _item.Image = _maper.Map<Image>(imageRes);
            _item.Type = typeRes;
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
            var typeRes = await Mediator.Send(new GetItemTypeById.Query { Id = item.Dto.TypeId });


            FoodItem _item = _maper.Map<FoodItem>(item);
            _item.Image = newImage != null ? _maper.Map<Image>(newImage) : null;
            _item.Type = typeRes;

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
