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
            CreateMap<FoodItem, FoodItemDTO>()
                .ForMember(dest =>
                    dest.Image,
                    opt => opt.Ignore())
                .ForPath(dest =>
                    dest.Dto.Image.Id,
                    opt => opt.MapFrom(src => src.Image.Id))
                .ForPath(dest =>
                    dest.Dto.Image.Url,
                    opt => opt.MapFrom(src => src.Image.Url))
                 .ForPath(dest =>
                    dest.Dto.Id,
                    opt => opt.MapFrom(src => src.Id))
                 .ForPath(dest =>
                    dest.Dto.Name,
                    opt => opt.MapFrom(src => src.Name))
                 .ForPath(dest =>
                    dest.Dto.Description,
                    opt => opt.MapFrom(src => src.Description))
                 .ForPath(dest =>
                    dest.Dto.TypeId,
                    opt => opt.MapFrom(src => src.Type.Id))
                 .ForPath(dest =>
                    dest.Dto.Price,
                    opt => opt.MapFrom(src => src.Price.Value))
                .ReverseMap()
                .ForPath(dest =>
                    dest.Image.Id,
                    opt => opt.MapFrom(src => src.Dto.Image.Id))
                 .ForPath(dest =>
                    dest.Image.Url,
                    opt => opt.MapFrom(src => src.Dto.Image.Url))
                .ForMember(dest =>
                    dest.Id,
                    opt => opt.MapFrom(src => src.Dto.Id))
                .ForMember(dest =>
                    dest.Name,
                    opt => opt.MapFrom(src => src.Dto.Name))
                .ForMember(dest =>
                    dest.Description,
                    opt => opt.MapFrom(src => src.Dto.Description))
                .ForPath(dest =>
                    dest.Type.Id,
                    opt => opt.MapFrom(src => src.Dto.TypeId))
                .ForPath(dest =>
                    dest.Price,
                    opt => opt.MapFrom(src => Price.From(src.Dto.Price)));
        }
    }
}
