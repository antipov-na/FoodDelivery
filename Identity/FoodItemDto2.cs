using Microsoft.AspNetCore.Http;

namespace Domain.Identity
{
    public class FoodItemDto2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypeId { get; set; }
        public decimal Price { get; set; }
        public IFormFile Image { get; set; }
    }
}
