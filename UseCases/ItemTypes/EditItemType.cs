using FoodDelivery.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;

namespace UseCases.ItemTypes
{
    public class EditItemType
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
                ItemType i = _context.ItemTypes.Find(request.ItemType.Id);
                i.Name = request.ItemType.Name;
                _ = await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
