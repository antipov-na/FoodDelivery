using UseCases.Core.Images;
using MediatR;
using UseCases.Core;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Images
{
    public class DeleteImage
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IImageService _imageService;
            private readonly IDeliveryContext _deliveryContext;

            public Handler(IImageService imageService, IDeliveryContext deliveryContext)
            {
                _imageService = imageService;
                _deliveryContext = deliveryContext;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var image = _deliveryContext.Images.Find(request.Id);
                _deliveryContext.Images.Remove(image);
                _ = _deliveryContext.SaveChangesAsync(cancellationToken);
                await _imageService.RemoveImage(request.Id);
                return Unit.Value;
            }
        }
    }
}
