using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;

namespace UseCases.ItemTypes
{
    public class AddItemType
    {
        public class Command : IRequest
        {
            public ItemType ItemType { get; set; }
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
                _context.ItemTypes.Add(request.ItemType);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
