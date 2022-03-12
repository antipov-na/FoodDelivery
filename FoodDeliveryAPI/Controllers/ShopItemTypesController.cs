using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.Core.DTOs;
using UseCases.ItemTypes;

namespace FoodDeliveryAPI.Controllers
{
    public class ShopItemTypesController : BaseApiController
    {
        [HttpGet]
        public async Task<List<GetItemTypeDto>> GetAllItemTypes()
        {
            return await Mediator.Send(new GetAllItemTypes.Query());
        }

        [HttpGet("{id}")]
        public async Task<GetItemTypeDto> GetItemTypeById(int id)
        {
            return await Mediator.Send(new GetItemTypeById.Query { Id = id });
        }

        [HttpPost]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<GetItemTypeDto>> AddItemType([FromForm] CreateItemTypeDto itemType)
        {
            return Ok(await Mediator.Send(new AddItemType.Command { ItemTypeDto = itemType }));
        }
        [HttpPut]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<ActionResult<GetItemTypeDto>> EditItemType([FromForm] EditItemTypeDto itemType)
        {
            return Ok(await Mediator.Send(new EditItemType.Command { ItemTypeDto = itemType }));
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteItemType(int id)
        {
            return Ok(await Mediator.Send(new DeleteItemType.Command { Id = id }));
        }
    }
}
