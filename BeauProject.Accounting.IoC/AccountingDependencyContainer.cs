using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Data.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeauProject.Accounting.IoC
{
    public static class AccountingDependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            #region Application Layer
            //service.AddMediatR(Assembly.GetExecutingAssembly());
            //service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(typeof(CreateBranchHandler).Assembly);
            service.AddMediatR(typeof(CreateRestaurantHandler).Assembly);
            service.AddMediatR(typeof(CreateFoodItemHandler).Assembly);
            service.AddMediatR(typeof(CreateModifierGroupHandler).Assembly);
            service.AddMediatR(typeof(CreateModifierItemHandler).Assembly);
            service.AddAutoMapper(typeof(BranchProfile).Assembly);
            service.AddAutoMapper(typeof(RestaurantProfile).Assembly);
            service.AddAutoMapper(typeof(FoodItemProfile).Assembly);
            service.AddAutoMapper(typeof(ModifierGroupProfile).Assembly);
            service.AddAutoMapper(typeof(ModifierItemProfile).Assembly);
            #endregion

            #region Data Layer
            service.AddScoped<IRestaurantRepository, RestaurantRepository>();
            service.AddDbContext<AccountingContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("Accounting")));
            #endregion

            #region Shared
            service.AddScoped<IEncrypter, Encrypter>();
            #endregion

            return service;
        }
    }
}
