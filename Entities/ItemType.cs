using CSharpFunctionalExtensions;

namespace Domain.Entities
{
    public class ItemType : Entity<int>
    {
        public string Name { get; set; }
    }
}