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
        public DbSet<Branch> Branches => Set<Branch>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RestaurantValidator());
            modelBuilder.ApplyConfiguration(new BranchValidator());
            base.OnModelCreating(modelBuilder);
        }
    }
}
