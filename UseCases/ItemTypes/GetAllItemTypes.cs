using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.DTOs;

namespace UseCases.ItemTypes
{
    public class GetAllItemTypes
    {
        public class Query : IRequest<List<GetItemTypeDto>> { }
        public class Handler : IRequestHandler<Query, List<GetItemTypeDto>>
        {
            readonly IDeliveryContext _context;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GetItemTypeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var items = await _context.ItemTypes.ToListAsync(cancellationToken: cancellationToken);

                return _mapper.Map<List<GetItemTypeDto>>(items);
            }
        }
    }
}
