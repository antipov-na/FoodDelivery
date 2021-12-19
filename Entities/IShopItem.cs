namespace FoodDelivery.Domain
{
    public interface IShopItem
    {
        int Id { get; set; }
        string Name { get; set; }
        ItemType Type { get; set; }
        string Description { get; set; }
        Image Image { get; set; }
        decimal Price { get; set; }
    }
}