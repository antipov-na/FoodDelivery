using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using UseCases.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Identity.Authentication;
using Domain.Entities.ValueObjects;

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
            builder
                .Entity<FoodItem>()
                .Property(e => e.Price)
                .HasConversion(
                    v => v.Value,
                    v => Price.From(v));
            base.OnModelCreating(builder);
        }
    }
}