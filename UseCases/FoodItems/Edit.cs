using UseCases.Core;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using UseCases.Core.DTOs;
using UseCases.Core.Images;
using System.Linq;
using System;

namespace UseCases.FoodItems
{
    public class Edit
    {
        public class Command : IRequest
        {
            public CreateFoodItemDto FoodItem { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IDeliveryContext _context;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //check if image exist
                Image image = _context.Images.SingleOrDefault(img => img.Id == request.FoodItem.Image.Id);
                if (image == null)
                {
                    throw new Exception("Изображение с таким id не существует. Сначала добавьте его.");
                }

                //check if type exist
                ItemType itemType = _context.ItemTypes.SingleOrDefault(type => type.Id == request.FoodItem.TypeId);
                if (itemType == null)
                {
                    throw new Exception("Тип с таким id не существует. Сначала добавьте его.");
                }

                FoodItem tempItem = _mapper.Map<FoodItem>(request.FoodItem);
                FoodItem i = _context.FoodItems.Find(tempItem);

                i.Name = request.FoodItem.Name;
                i.Description = request.FoodItem.Description;
                i.Type = itemType;
                i.Image = request.FoodItem.Image;
                i.Price = tempItem.Price;

                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
