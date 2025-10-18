using BeauProject.Shared.Application.Features.FilesType.Handler.Command;
using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Application.Profilers;
using BeauProject.Shared.Data.Context;
using BeauProject.Shared.Data.Repositories;
using BeauProject.Shared.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeauProject.Shared.IoC
{
    public static class SharedDependencyContainer
    {
        public static IServiceCollection RegisterSharedServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            #region Application Layer
            //service.AddMediatR(Assembly.GetExecutingAssembly());
            //service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(typeof(SetFilesHandler).Assembly);
            service.AddAutoMapper(typeof(RestaurantAutoMapperProfiler).Assembly);
            #endregion

            #region Data Layer
            service.AddScoped<IFilesRepository, FilesRepository>();
            service.AddDbContext<SharedContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("BeauManager")));
            #endregion

            return service;
        }
    }
}
