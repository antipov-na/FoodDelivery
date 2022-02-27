using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.DTOs;

namespace UseCases.ItemTypes
{
    public class EditItemType
    {
        public class Command : IRequest
        {
            public EditItemTypeDto ItemTypeDto { get; set; }
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
                ItemType i = _context.ItemTypes.Find(request.ItemTypeDto.Id);
                i.Name = request.ItemTypeDto.Name;
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
