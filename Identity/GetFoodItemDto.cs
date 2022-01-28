using Domain.Entities;

namespace Domain.Identity
{
    public class GetFoodItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public decimal Price { get; set; }
        public Image Image { get; set; }
    }
}
