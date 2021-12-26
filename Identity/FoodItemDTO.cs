using Microsoft.AspNetCore.Http;

namespace Domain.Identity
{
    public class FoodItemDTO
    {
        public class Data
        {
            public string Description { get; set; }
            public decimal Price { get; set; }
            public int Id { get; set; }
            public string Name { get; set; }
            public int TypeId { get; set; }
        }

        public Data Dto { get; set; }

        public IFormFile Image { get; set; }
    }
}
