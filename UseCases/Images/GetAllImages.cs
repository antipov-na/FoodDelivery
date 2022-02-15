using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.DTOs;

namespace UseCases.Images
{
    public class GetAllImages
    {
        public class Query : IRequest<List<GetImageDto>> { }

        public class Handler : IRequestHandler<Query, List<GetImageDto>>
        {
            private readonly IDeliveryContext _context;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<GetImageDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var images = await _context.Images.ToListAsync(cancellationToken: cancellationToken);

                return _mapper.Map<List<GetImageDto>>(images);
            }
        }

    }
}
