using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BeauProject.Shared.Data.Context
{
    public class AppSharedContextFactory : IDesignTimeDbContextFactory<SharedContext>
    {
        public SharedContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SharedContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=BeauManager;Integrated Security=True;Trusted_Connection=True;TrustServerCertificate=True;");
            return new SharedContext(optionsBuilder.Options);
        }
    }
}

///Run in powershell for ef core create migration and connection
//1.dotnet tool install --global dotnet-ef
//2.dotnet ef migrations add InitialCreate    
//3.dotnet ef database update
