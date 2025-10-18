using BeauProject.Restaurant.Data.EntityValidator;
using BeauProject.Restaurant.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Data.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options) { }

        public DbSet<RestaurantEntity> Restaurants => Set<RestaurantEntity>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestaurantValidator());
            base.OnModelCreating(modelBuilder);
        }
    }
}
