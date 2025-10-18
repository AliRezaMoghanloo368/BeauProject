using BeauProject.Restaurant.Data.Repositories;
using BeauProject.Restaurant.Domain.Interfaces;
using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Application.Profilers;
using BeauProject.Shared.Data.Services;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using BeauProject.Restaurant.Application.Features.RestaurantType.Handler.Command;

namespace BeauProject.Restaurant.Data.Context
{
    public static class RestaurantDependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            #region Application Layer
            //service.AddMediatR(Assembly.GetExecutingAssembly());
            //service.AddAutoMapper(Assembly.GetExecutingAssembly());
            //service.AddMediatR(typeof(CreateRestaurantHandler).Assembly);
            service.AddAutoMapper(typeof(RestaurantAutoMapperProfiler).Assembly);
            #endregion

            #region Data Layer
            service.AddScoped<IRestaurantRepository, RestaurantRepository>();
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
