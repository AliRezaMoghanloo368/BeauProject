using BeauProject.Restaurant.Application.Features.BranchType.Handle.Command;
using BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Command;
using BeauProject.Restaurant.Application.Profilers;
using BeauProject.Restaurant.Data.Context;
using BeauProject.Restaurant.Data.Repositories;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Data.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeauProject.Restaurant.IoC
{
    public static class RestaurantDependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            #region Application Layer
            //service.AddMediatR(Assembly.GetExecutingAssembly());
            //service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(typeof(CreateBranchHandler).Assembly);
            service.AddMediatR(typeof(CreateRestaurantHandler).Assembly);
            service.AddAutoMapper(typeof(BranchProfile).Assembly);
            service.AddAutoMapper(typeof(RestaurantProfile).Assembly);
            #endregion

            #region Data Layer
            service.AddScoped<IRestaurantRepository, RestaurantRepository>();
            service.AddScoped<IBranchRepository, BranchRepository>();
            service.AddDbContext<RestaurantContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("Restaurant")));
            #endregion

            #region Shared
            service.AddScoped<IEncrypter, Encrypter>();
            #endregion

            return service;
        }
    }
}
