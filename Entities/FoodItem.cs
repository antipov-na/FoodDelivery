using CSharpFunctionalExtensions;
using Domain.Entities.ValueObjects;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class FoodItem : Entity<int>
    {
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public string Description { get; set; }
        public Image Image { get; set; }
        public Price Price { get; set; }
    }
}
