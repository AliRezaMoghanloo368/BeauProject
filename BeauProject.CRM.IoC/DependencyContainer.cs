//using Microsoft.Extensions.DependencyInjection;
using BeauProject.CRM.Application.Features;
using BeauProject.CRM.Application.Interfaces;
using BeauProject.CRM.Data.Repositories;
using BeauProject.CRM.Domain.Interfaces;
using BeauProject.Identity.Data.Context;
using BeauProject.Shared.Application.Interfaces;
using BeauProject.Shared.Application.Profilers;
using BeauProject.Shared.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BeauProject.CRM.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            #region Application Layer
            //service.AddMediatR(Assembly.GetExecutingAssembly());
            //service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddScoped<ISPService, SPService>();
            service.AddAutoMapper(typeof(AutoMapperProfiler).Assembly);
            #endregion

            #region Data Layer
            service.AddScoped<ISPCRMRepository, SPCRMRepository>();
            service.AddDbContext<CRMContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("BeauManager")));
            #endregion

            #region Shared Layer
            service.AddScoped<IEncrypter, Encrypter>();
            #endregion

            return service;
        }
    }
}
