using AutoMapper;
using FoodDelivery.Domain;

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
