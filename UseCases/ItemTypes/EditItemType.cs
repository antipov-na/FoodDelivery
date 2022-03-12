using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.DTOs;

namespace UseCases.ItemTypes
{
    public class EditItemType
    {
        public class Command : IRequest<GetItemTypeDto>
        {
            public EditItemTypeDto ItemTypeDto { get; set; }
        }

        public class Handler : IRequestHandler<Command, GetItemTypeDto>
        {
            private readonly IDeliveryContext _context;
            private readonly IMapper _mapper;

            public Handler(IDeliveryContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GetItemTypeDto> Handle(Command request, CancellationToken cancellationToken)
            {
                ItemType i = _context.ItemTypes.Find(request.ItemTypeDto.Id);
                i.Name = request.ItemTypeDto.Name;
                _ = await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<GetItemTypeDto>(i);
            }
        }
    }
}
