using UseCases.Core;
using FoodDelivery.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.FoodItems
{
    public class Add
    {
        public class Command : IRequest
        {
            public FoodItem FoodItem { get; set; } 
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
                _context.FoodItems.Add(request.FoodItem);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
