using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace UseCases.Core.DTOs
{
    public class CreateFoodItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public string ImageId { get; set; }
    }
}
