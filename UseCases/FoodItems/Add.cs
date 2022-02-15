using UseCases.Core;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core.DTOs;
using AutoMapper;
using UseCases.Core.Images;
using Microsoft.EntityFrameworkCore;

namespace UseCases.FoodItems
{
    public class Add
    {
        public class Command : IRequest
        {
            public CreateFoodItemDto FoodItem { get; set; } 
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IDeliveryContext _context;
            private readonly IImageService _imageService;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IImageService imageService, IMapper mapper)
            {
                _context = context;
                _imageService = imageService;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                FoodItem item = _mapper.Map<FoodItem>(request.FoodItem);

                item.Image = await _context.Images.SingleOrDefaultAsync(i => i.Id == request.FoodItem.Image.Id, cancellationToken: cancellationToken);
                item.Type = await _context.ItemTypes.SingleOrDefaultAsync(i => i.Id == request.FoodItem.TypeId, cancellationToken: cancellationToken);

                _context.FoodItems.Add(item);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
