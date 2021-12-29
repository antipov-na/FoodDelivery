using System.Collections.Generic;
using Domain.Identity;
using Domain.Entities;

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