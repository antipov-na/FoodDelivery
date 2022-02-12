﻿using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using System.Collections.Generic;
using UseCases.FoodItems;
using UseCases.Images;
using UseCases.Core.Images;
using System.Threading.Tasks;
using UseCases.ItemTypes;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using UseCases.Core.Authentication;
using UseCases.Core.DTOs;

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
        public async Task<ActionResult<List<GetFoodItemDto>>> GetAll()
        {
            var res = await Mediator.Send(new GetAll.Query());
            return Ok(_maper.Map<List<GetFoodItemDto>>(res));
        }

        // GET: api/index/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetFoodItemDto>> GetItemById(int id)
        {
            var res = await Mediator.Send(new GetById.Query { Id = id });
            return Ok(_maper.Map<GetFoodItemDto>(res));
        }

        // GET: api/index/GetRange/{startId}/amount/{amount}
        [HttpGet("GetRange/{startId}/amount/{amount}")]
        public async Task<ActionResult<List<GetFoodItemDto>>> GetItemByRange(int startId, int amount)
        {
            var res = await Mediator.Send(new GetByRange.Query { StartId = startId, Range = amount });
            return Ok(_maper.Map<GetFoodItemDto>(res));
        }

        // POST: api/index
        [HttpPost]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> AddItem([FromForm] CreateFoodItemDto item)
        {
            var imageRes = await Mediator.Send(new AddImage.Command { Image = item.Image });
            var typeRes = await Mediator.Send(new GetItemTypeById.Query { Id = item.TypeId });
            FoodItem _item = _maper.Map<FoodItem>(item);
            _item.Image = _maper.Map<Image>(imageRes);
            _item.Type = typeRes;
            return Ok(await Mediator.Send(new Add.Command { FoodItem = _item }));
        }

        // PUT: api/index
        [HttpPut]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> EditItem([FromForm] CreateFoodItemDto item)
        {
            CloudinaryApiResult newImage = null;
            FoodItem _item = _maper.Map<FoodItem>(item);
            if (item.Image != null)
            {
                await Mediator.Send(new DeleteImageByShopItemId.Command { ShopItemId = _item.Id });
                newImage = await Mediator.Send(new AddImage.Command { Image = item.Image });
            }

            var typeRes = await Mediator.Send(new GetItemTypeById.Query { Id = item.TypeId });

            _item.Image = newImage != null ? _maper.Map<Image>(newImage) : null;
            _item.Type = typeRes;

            return Ok(await Mediator.Send(new Edit.Command { FoodItem = _item }));
        }

        //DELETE: api/index/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await Mediator.Send(new GetById.Query { Id = id });
            await Mediator.Send(new DeleteImage.Command { Id = item.Image.Id });
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
