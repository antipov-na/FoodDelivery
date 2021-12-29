using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;

namespace UseCases.ItemTypes
{
    public class GetAllItemTypes
    {
        public class Query : IRequest<List<ItemType>> { }
        public class Handler : IRequestHandler<Query, List<ItemType>>
        {
            readonly IDeliveryContext _context;

            public Handler(IDeliveryContext context)
            {
                _context = context;
            }

            public async Task<List<ItemType>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.ItemTypes.ToListAsync(cancellationToken: cancellationToken);
            }
        }
    }
}
