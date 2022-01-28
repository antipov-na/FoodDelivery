using System.Collections.Generic;
using Domain.Identity;
using Domain.Entities;

namespace FoodDelivery.Persistence
{
    public interface IDataProvider
    {
        void AddItem(CreateFoodItemDto item);
        void DeleteItem(int id);
        void EditItem(CreateFoodItemDto item);
        IEnumerable<FoodItem> GetAll();
        FoodItem GetItemById(int id);
    }
}