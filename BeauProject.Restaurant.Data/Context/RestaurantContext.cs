using BeauProject.Restaurant.Data.EntityValidator;
using BeauProject.Restaurant.Data.EntityValidator.AccountsValidator;
using BeauProject.Restaurant.Data.EntityValidator.MenuValidator;
using BeauProject.Restaurant.Domain.Models;
using BeauProject.Restaurant.Domain.Models.Accounts;
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

        #region Menu
        public DbSet<Menu> Menus { get; set; } = null!;
        public DbSet<MenuTranslation> MenuTranslations { get; set; } = null!;
        public DbSet<MenuCategory> MenuCategories { get; set; } = null!;
        public DbSet<MenuCategoryTranslation> MenuCategoryTranslations { get; set; } = null!;
        public DbSet<MenuItemPrice> MenuItemPrices { get; set; } = null!;
        #endregion

        #region Food
        public DbSet<FoodItem> FoodItems { get; set; } = null!;
        public DbSet<FoodAddonOption> FoodAddonOptions { get; set; } = null!;
        #endregion

        //#region Modifier
        //public DbSet<ModifierGroup> ModifierGroups { get; set; } = null!;
        //public DbSet<ModifierItem> ModifierItems { get; set; } = null!;
        //#endregion

        #region Modifier
        public DbSet<AccountGroup> AccountGroups { get; set; } = null!;
        public DbSet<AccountGroupTranslation> AccountGroupTranslations { get; set; } = null!;
        public DbSet<AccountSubGroup> AccountSubGroups { get; set; } = null!;
        public DbSet<AccountSubGroupTranslation> AccountSubGroupTranslations { get; set; } = null!;
        public DbSet<AccountDetail> AccountDetails { get; set; } = null!;
        public DbSet<AccountDetailTranslation> AccountDetailTranslations { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ✅ Fluent API Configurations
            modelBuilder.ApplyConfiguration(new RestaurantValidator());
            modelBuilder.ApplyConfiguration(new BranchValidator());
            modelBuilder.ApplyConfiguration(new TableValidator());
            modelBuilder.ApplyConfiguration(new MenuConfigurationValidator());
            modelBuilder.ApplyConfiguration(new MenuTranslationValidator());
            modelBuilder.ApplyConfiguration(new MenuCategoryValidator());
            modelBuilder.ApplyConfiguration(new MenuCategoryTranslationValidator());
            modelBuilder.ApplyConfiguration(new MenuItemPriceValidator());
            modelBuilder.ApplyConfiguration(new FoodItemValidator());
            modelBuilder.ApplyConfiguration(new FoodAddonOptionValidator());
            //modelBuilder.ApplyConfiguration(new ModifierGroupValidator());
            //modelBuilder.ApplyConfiguration(new ModifierItemValidator());
            // ✅ Accounts
            modelBuilder.ApplyConfiguration(new AccountGroupValidator());
            modelBuilder.ApplyConfiguration(new AccountGroupTranslationValidator());
            modelBuilder.ApplyConfiguration(new AccountSubGroupValidator());
            modelBuilder.ApplyConfiguration(new AccountSubGroupTranslationValidator());
            modelBuilder.ApplyConfiguration(new AccountDetailValidator());
            modelBuilder.ApplyConfiguration(new AccountDetailTranslationValidator());

            base.OnModelCreating(modelBuilder);
        }
    }
}
