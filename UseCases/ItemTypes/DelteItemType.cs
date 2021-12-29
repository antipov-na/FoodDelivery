using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;

namespace UseCases.ItemTypes
{
    public class DeleteItemType
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IDeliveryContext _context;
            public Handler(IDeliveryContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                ItemType i = _context.ItemTypes.Find(request.Id);
                if (_context.FoodItems.Any(e => e.Type == i))
                {
                    return Unit.Value;
                }
                _context.ItemTypes.Remove(i);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
