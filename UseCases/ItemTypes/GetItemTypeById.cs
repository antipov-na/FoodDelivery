using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;

namespace UseCases.ItemTypes
{
    public class GetItemTypeById
    {
        public class Query : IRequest<ItemType>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ItemType>
        {
            readonly IDeliveryContext _context;

            public Handler(IDeliveryContext context)
            {
                _context = context;
            }

            public async Task<ItemType> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.ItemTypes.SingleOrDefaultAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);
            }
        }
    }
}
