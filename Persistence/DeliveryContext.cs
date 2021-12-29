using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using UseCases.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Identity.Authentication;

namespace FoodDelivery.Persistence
{
    public class DeliveryContext : IdentityDbContext<ApplicationUser>, IDeliveryContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options)
            : base(options)
        {

        }

        public virtual DbSet<FoodItem> FoodItems { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}