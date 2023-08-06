using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.Database
{
    public interface IDatabaseBuilder
    {
        void OnConfiguring(DbContextOptionsBuilder optionsBuilder);
    }
}
