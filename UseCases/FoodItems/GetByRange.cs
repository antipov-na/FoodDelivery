using UseCases.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core.DTOs;
using AutoMapper;

namespace UseCases.FoodItems
{
    public class GetByRange
    {
        public class Query : IRequest<List<GetFoodItemDto>>
        {
            public int StartId { get; set; }
            public int Range { get; set; }
        }
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
                                                     .Include(e => e.Type)
                                                     .Where(i => i.Id >= request.StartId && i.Id < request.StartId + request.Range)
                                                     .ToListAsync(cancellationToken: cancellationToken);

                return _mapper.Map<List<GetFoodItemDto>>(items);
            }
        }
    }
}