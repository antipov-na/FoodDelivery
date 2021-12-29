using UseCases.Core;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.FoodItems
{
    public class GetAll
    {
        public class Query : IRequest<List<FoodItem>> { }
        public class Handler : IRequestHandler<Query, List<FoodItem>>
        {
            readonly IDeliveryContext _context;

            public Handler(IDeliveryContext context)
            {
                _context = context;
            }

            public async Task<List<FoodItem>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FoodItems.Include(f => f.Image).Include(e=> e.Type).ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
