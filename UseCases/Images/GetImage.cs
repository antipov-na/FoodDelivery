using CloudinaryDotNet.Actions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core.Images;

namespace UseCases.Images
{
    public class GetImage
    {
        public class Query : IRequest<GetResourceResult> 
        { 
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, GetResourceResult>
        {
            private readonly IImageService _imageService;

            public Handler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<GetResourceResult> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _imageService.GetImage(request.Id);
            }
        }
    }
}
