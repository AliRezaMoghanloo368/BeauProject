using Microsoft.EntityFrameworkCore;
using BeauProject.Identity.Data.EntityValidator;
using BeauProject.Identity.Domain.Models;
using System.Runtime.InteropServices;

namespace BeauProject.Identity.Data.Context
{
    public class IdentityContext : DbContext
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {

        }

        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserValidator());
        }
    }
}


//create migration:
///Run in powershell for ef core create migration and connection
//1.dotnet tool install --global dotnet-ef
//2.dotnet ef migrations add InitialCreate    
//3.dotnet ef database update

///'PS D:\Projects\Web\BeauProject\BeauProject.Identity.Data> dotnet ef migrations add InitialCreate'