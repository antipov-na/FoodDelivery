using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.Images;

namespace UseCases.Images
{
    public class DeleteImageByShopItemId
    {
        public class Command : IRequest
        {
            public int ShopItemId { get; set; }
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
                var shopItem = _deliveryContext.FoodItems.Find(request.ShopItemId);
                var image = _deliveryContext.Images.Find(shopItem.Image.Id);
                _deliveryContext.Images.Remove(image);
                _ = _deliveryContext.SaveChangesAsync(cancellationToken);
                await _imageService.RemoveImage(image.Id);
                return Unit.Value;
            }
        }
    }
}
