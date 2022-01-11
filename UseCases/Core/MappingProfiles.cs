using AutoMapper;
using Domain.Entities;
using Domain.Entities.ValueObjects;
using Domain.Identity;
using System.Collections.Generic;
using UseCases.Core.Images;

namespace UseCases.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CloudinaryApiResult, Image>()
                .ReverseMap();
            CreateMap<FoodItem, FoodItem>();

            CreateMap<FoodItem, FoodItemDto1>()
                .ForMember(dest =>
                    dest.Price,
                    opt => opt.MapFrom(src => src.Price.Value))
                .ReverseMap()
                .ForMember(dest =>
                    dest.Price,
                    opt => opt.MapFrom(src => Price.From(src.Price)));

            CreateMap<FoodItemDto2, FoodItem>()
                .ForMember(dest =>
                    dest.Type,
                    opt => opt.Ignore())
                 .ForMember(dest =>
                    dest.Price,
                     opt => opt.MapFrom(src => Price.From(src.Price)))
                 .ForMember(dest =>
                    dest.Image,
                    opt => opt.Ignore());
        }
    }
}
