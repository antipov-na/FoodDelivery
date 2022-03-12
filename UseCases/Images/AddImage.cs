using UseCases.Core.Images;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using UseCases.Core;
using Domain.Entities;
using UseCases.Core.DTOs;

namespace UseCases.Images
{
    public class AddImage
    {
        public class Command : IRequest<GetImageDto>
        {
            public CreateImageDto ImageDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, GetImageDto>
        {
            private readonly IDeliveryContext _context;
            private readonly IImageService _imageService;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IImageService imageService, IMapper mapper)
            {
                _context = context;
                _imageService = imageService;
                _mapper = mapper;
            }

            public async Task<GetImageDto> Handle(Command request, CancellationToken cancellationToken)
            {
                var image = await _imageService.AddImage(request.ImageDto.Image);
                _context.Images.Add(_mapper.Map<Image>(image));
                _ = await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<GetImageDto>(image);
            }
        }
    }
}
