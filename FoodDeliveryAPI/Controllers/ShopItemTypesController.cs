using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using UseCases.Core.Authentication;
using UseCases.ItemTypes;
    
namespace FoodDeliveryAPI.Controllers
{
    public class ShopItemTypesController : BaseApiController
    {
        [HttpGet]
        public async Task<List<ItemType>> GetAllItemTypes()
        {
            return await Mediator.Send(new GetAllItemTypes.Query());
        }

        [HttpGet("{id}")]
        public async Task<ItemType> GetItemTypeById(int id)
        {
            return await Mediator.Send(new GetItemTypeById.Query { Id = id });
        }

        [HttpPost]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddItemType([FromForm] ItemType itemType)
        {
            return Ok(await Mediator.Send(new AddItemType.Command { ItemType = itemType }));
        }
        [HttpPut]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> EditItemType([FromForm] ItemType itemType)
        {
            return Ok(await Mediator.Send(new EditItemType.Command { ItemType = itemType }));
        }
        [HttpDelete("{id}")]
        //[Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteItemType(int id)
        {
            return Ok(await Mediator.Send(new DeleteItemType.Command { Id = id }));
        }
    }
}
