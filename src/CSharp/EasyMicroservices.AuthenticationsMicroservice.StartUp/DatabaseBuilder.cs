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
        public override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var entity = GetEntity();
            if (entity.IsSqlServer())
                optionsBuilder.UseSqlServer(entity.ConnectionString);
            else if (entity.IsInMemory())
                optionsBuilder.UseInMemoryDatabase("Authentication");
        }
    }
}
