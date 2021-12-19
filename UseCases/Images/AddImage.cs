using UseCases.Core.Images;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Images
{
    public class AddImage
    {
        public class Command : IRequest<CloudinaryApiResult>
        {
            public IFormFile Image { get; set; }
        }

        public class Handler : IRequestHandler<Command, CloudinaryApiResult>
        {
            private readonly IImageService _imageService;

            public Handler(IImageService imageService)
            {
                _imageService = imageService;
            }

            public async Task<CloudinaryApiResult> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _imageService.AddImage(request.Image);
            }
        }
    }
}
