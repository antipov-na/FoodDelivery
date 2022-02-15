using UseCases.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core.DTOs;
using AutoMapper;

namespace UseCases.FoodItems
{
    public class GetById
    {
        public class Query : IRequest<GetFoodItemDto> {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GetFoodItemDto>
        {
            readonly IDeliveryContext _context;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetFoodItemDto> Handle(Query request, CancellationToken cancellationToken)
            {
                FoodItem item =  await _context.FoodItems
                                               .Include(f => f.Image)
                                               .Include(e => e.Type)
                                               .SingleOrDefaultAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

                return _mapper.Map<GetFoodItemDto>(item);
            }
        }
    }
}
