using System.Collections.Generic;
using Domain.Entities;
using UseCases.Core.DTOs;

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