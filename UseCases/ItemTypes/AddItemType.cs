using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UseCases.Core;
using UseCases.Core.DTOs;

namespace UseCases.ItemTypes
{
    public class AddItemType
    {
        public class Command : IRequest<GetItemTypeDto>
        {
            public CreateItemTypeDto ItemTypeDto { get; set; }
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
                var item = _mapper.Map<ItemType>(request.ItemTypeDto);
                _context.ItemTypes.Add(item);
                _ = await _context.SaveChangesAsync(cancellationToken);
                return _mapper.Map<GetItemTypeDto>(item);
            }
        }
    }
}
