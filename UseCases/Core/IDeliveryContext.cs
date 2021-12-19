using FoodDelivery.Domain;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace UseCases.Core
{
    public interface IDeliveryContext
    {
        DbSet<FoodItem> FoodItems { get; set; }
        DbSet<Image> Images { get; set; }
        DbSet<ItemType> ItemTypes { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

}
