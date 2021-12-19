using UseCases.Core;
using FoodDelivery.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.FoodItems
{
    public class GetById
    {
        public class Query : IRequest<FoodItem> {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, FoodItem>
        {
            readonly IDeliveryContext _context;

            public Handler(IDeliveryContext context)
            {
                _context = context;
            }

            public async Task<FoodItem> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.FoodItems.Include(f => f.Image).Include(e => e.Type).SingleOrDefaultAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);
            }
        }
    }
}
