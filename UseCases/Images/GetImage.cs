using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.DTOs;
using UseCases.Core.Images;

namespace UseCases.Images
{
    public class GetImage
    {
        public class Query : IRequest<GetImageDto> 
        { 
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GetImageDto>
        {
            private readonly IDeliveryContext _context;

            public Handler( IDeliveryContext context )
            {
                _context = context;
            }

            public async Task<GetImageDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var image = await _context.Images.SingleOrDefaultAsync(i => i.Id == request.Id, cancellationToken: cancellationToken);

                return new GetImageDto() { Id = image.Id, Url = image.Url };
            }
        }
    }
}
