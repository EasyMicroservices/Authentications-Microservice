using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyMicroservices.AuthenticationsMicroservice
{
    public class DatabaseBuilder : EntityFrameworkCoreDatabaseBuilder
    {
        public DatabaseBuilder(IConfiguration configuration) : base(configuration)
        {
        }

        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder, string name)
        {
            if (name == "SqlServer")
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("local"));
            else
                optionsBuilder.UseInMemoryDatabase("Authentication");
        }
    }
}
