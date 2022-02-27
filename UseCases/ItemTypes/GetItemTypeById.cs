using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.DTOs;

namespace UseCases.ItemTypes
{
    public class GetItemTypeById
    {
        public class Query : IRequest<GetItemTypeDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GetItemTypeDto>
        {
            readonly IDeliveryContext _context;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetItemTypeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var item = await _context.ItemTypes.SingleOrDefaultAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

                return _mapper.Map<GetItemTypeDto>(item);
            }
        }
    }
}
