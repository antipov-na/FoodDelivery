using System.Collections.Generic;
using FoodDelivery.Domain;

namespace FoodDelivery.Persistence
{
    public interface IDataProvider
    {
        void AddItem(FoodItemDTO item);
        void DeleteItem(int id);
        void EditItem(FoodItemDTO item);
        IEnumerable<FoodItem> GetAll();
        FoodItem GetItemById(int id);
    }
}