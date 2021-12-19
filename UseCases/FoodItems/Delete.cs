using UseCases.Core;
using FoodDelivery.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.FoodItems
{
    public class Delete
    {
        public class Command : IRequest
        {
            public int Id{ get; set; }
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
                FoodItem i = _context.FoodItems.Find(request.Id);
                _context.FoodItems.Remove(i);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
