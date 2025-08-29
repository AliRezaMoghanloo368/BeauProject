using BeauProject.Identity.Application.Features.UserType.Handler.Command;
using BeauProject.Identity.Application.Interfaces;
using BeauProject.Identity.Application.Profilers;
using BeauProject.Identity.Application.Services;
using BeauProject.Identity.Data.Context;
using BeauProject.Identity.Data.Repositories;
using BeauProject.Identity.Domain.Interfaces;
using BeauProject.Shared.Implements;
using BeauProject.Shared.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace BeauProject.Identity.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection service,
            IConfiguration configuration)
        {
            #region Application Layer
            service.AddScoped<IJwtHandler, JwtHandler>();
            //service.AddMediatR(Assembly.GetExecutingAssembly());
            //service.AddAutoMapper(Assembly.GetExecutingAssembly());
            service.AddMediatR(typeof(RegisterUserHandler).Assembly);
            service.AddAutoMapper(typeof(AutoMapperProfiler).Assembly);
            #endregion

            #region Data Layer
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddDbContext<IdentityContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("BeauManager")));
            #endregion

            #region Auth
            service.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateLifetime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["jwt:key"]))
                };
            });
            #endregion

            #region Shared Layer
            service.AddScoped<IEncrypter, Encrypter>();
            #endregion

            return service;
        }
    }
}
