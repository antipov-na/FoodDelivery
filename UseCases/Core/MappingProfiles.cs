using AutoMapper;
using Domain.Entities;

namespace UseCases.Core
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<FoodItem, FoodItem>();
        }
    }
}
