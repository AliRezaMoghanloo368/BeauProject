using BeauProject.Shared.Data.EntityValidator;
using BeauProject.Shared.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BeauProject.Shared.Data.Context
{
    public class SharedContext : DbContext
    {
        public SharedContext(DbContextOptions<SharedContext> options) : base(options)
        {

        }

        public DbSet<Files> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new FilesValidator());
        }
    }
}


//create migration:
///Run in powershell for ef core create migration and connection
//1.dotnet tool install --global dotnet-ef
//2.dotnet ef migrations add InitialCreate    
//3.dotnet ef database update

///'PS D:\Projects\Web\BeauProject\BeauProject.Identity.Data> dotnet ef migrations add InitialCreate'