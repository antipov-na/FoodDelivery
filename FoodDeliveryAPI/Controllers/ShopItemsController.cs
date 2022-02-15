using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using UseCases.FoodItems;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using UseCases.Core.Authentication;
using UseCases.Core.DTOs;

namespace FoodDeliveryAPI.Controllers
{
    public class ShopItemsController : BaseApiController
    {
        // GET: api/index
        [HttpGet]
        public async Task<ActionResult<List<GetFoodItemDto>>> GetAll()
        {
            var res = await Mediator.Send(new GetAll.Query());
            return Ok(res);
        }

        // GET: api/index/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetFoodItemDto>> GetItemById(int id)
        {
            var res = await Mediator.Send(new GetById.Query { Id = id });
            return Ok(res);
        }

        // GET: api/index/GetRange/{startId}/amount/{amount}
        [HttpGet("GetRange/{startId}/amount/{amount}")]
        public async Task<ActionResult<List<GetFoodItemDto>>> GetItemByRange(int startId, int amount)
        {
            var res = await Mediator.Send(new GetByRange.Query { StartId = startId, Range = amount });
            return Ok(res);
        }

        // POST: api/index
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddItem([FromForm] CreateFoodItemDto item)
        {
            var res = await Mediator.Send(new Add.Command { FoodItem = item });
            return Ok(res);
        }

        // PUT: api/index
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> EditItem([FromForm] CreateFoodItemDto item)
        {
            var res = await Mediator.Send(new Edit.Command { FoodItem = item });
            return Ok(res);
        }

        //DELETE: api/index/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var res = await Mediator.Send(new Delete.Command { Id = id });
            return Ok(res);
        }
    }
}
