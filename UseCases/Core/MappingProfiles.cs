using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;
using UseCases.Core.DTOs;
using UseCases.Core.Images;

namespace UseCases.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CloudinaryApiResult, Image>()
                .ReverseMap();
            CreateMap<CloudinaryApiResult, GetImageDto>()
                .ReverseMap();
            CreateMap<FoodItem, FoodItem>();
            CreateMap<GetImageDto, Image>()
                .ReverseMap();
            CreateMap<FoodItem, GetFoodItemDto>()
                .ForMember(dest =>
                    dest.Price,
                    opt => opt.MapFrom(src => src.Price.Value))
                .ReverseMap()
                .ForMember(dest =>
                    dest.Price,
                    opt => opt.MapFrom(src => Price.From(src.Price)));

            CreateMap<CreateFoodItemDto, FoodItem>()
                .ForMember(dest =>
                    dest.Type,
                    opt => opt.Ignore())
                 .ForMember(dest =>
                    dest.Price,
                     opt => opt.MapFrom(src => Price.From(src.Price)))
                 .ForMember(dest =>
                    dest.Image,
                    opt => opt.Ignore());

            CreateMap<EditItemTypeDto, ItemType>()
                .ReverseMap();
            CreateMap<GetItemTypeDto, ItemType>()
               .ReverseMap();
            CreateMap<CreateItemTypeDto, ItemType>()
                .ReverseMap();
        }
    }
}
