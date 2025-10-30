using BeauProject.Restaurant.Data.EntityValidator;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Restaurant.Domain.Models.Menu;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Restaurant.Data.Context
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options) { }

        public DbSet<RestaurantEntity> Restaurants { get; set; } = null!;
        public DbSet<Branch> Branches { get; set; } = null!;
        public DbSet<Table> Tables { get; set; } = null!;
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<MenuCategory> MenuCategories { get; set; } = null!;
        public DbSet<MenuTranslation> MenuTranslations { get; set; } = null!;
        public DbSet<MenuItemPrice> MenuItemPrices { get; set; } = null!;
        public DbSet<FoodItem> FoodItems { get; set; } = null!;
        public DbSet<FoodAddonOption> FoodAddonOptions { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Fluent API Configurations
            modelBuilder.ApplyConfiguration(new RestaurantValidator());
            modelBuilder.ApplyConfiguration(new BranchValidator());
            modelBuilder.ApplyConfiguration(new FoodItemValidator());
            modelBuilder.ApplyConfiguration(new FoodAddonOptionValidator());
            modelBuilder.ApplyConfiguration(new MenuConfigurationValidator());
            modelBuilder.ApplyConfiguration(new MenuTranslationValidator());
            modelBuilder.ApplyConfiguration(new MenuCategoryValidator());
            modelBuilder.ApplyConfiguration(new MenuItemPriceValidator());
            modelBuilder.ApplyConfiguration(new TableValidator());

            base.OnModelCreating(modelBuilder);
        }
    }
}
