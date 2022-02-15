using UseCases.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core.DTOs;
using AutoMapper;

namespace UseCases.FoodItems
{
    public class GetAll
    {
        public class Query : IRequest<List<GetFoodItemDto>> { }
        public class Handler : IRequestHandler<Query, List<GetFoodItemDto>>
        {
            readonly IDeliveryContext _context;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GetFoodItemDto>> Handle(Query request, CancellationToken cancellationToken)
            {
               List<FoodItem> items = await _context.FoodItems
                                                   .Include(f => f.Image)
                                                   .Include(e=> e.Type)
                                                   .ToListAsync(cancellationToken: cancellationToken);

                return _mapper.Map<List<GetFoodItemDto>>(items);
            }
        }
    }
}
