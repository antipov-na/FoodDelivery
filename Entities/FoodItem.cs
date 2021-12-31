using System.Collections.Generic;

namespace Domain.Entities
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public decimal Price { get; set; }
    }
}
