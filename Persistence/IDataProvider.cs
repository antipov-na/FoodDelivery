using System.Collections.Generic;
using Domain.Identity;
using Domain.Entities;

namespace FoodDelivery.Persistence
{
    public interface IDataProvider
    {
        void AddItem(FoodItemDto2 item);
        void DeleteItem(int id);
        void EditItem(FoodItemDto2 item);
        IEnumerable<FoodItem> GetAll();
        FoodItem GetItemById(int id);
    }
}