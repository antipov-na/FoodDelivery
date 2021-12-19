using UseCases.Core;
using FoodDelivery.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.FoodItems
{
    public class Edit
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
                FoodItem i = _context.FoodItems.Find(request.FoodItem.Id);

                i.Name = request.FoodItem.Name;
                i.Description = request.FoodItem.Description;
                if (request.FoodItem.Image != null)
                {
                    i.Image = request.FoodItem.Image;
                }
                i.Price = request.FoodItem.Price;
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
