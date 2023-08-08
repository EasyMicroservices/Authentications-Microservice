using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Contexts
{
    public class AuthenticationsContext : DbContext
    {
        IDatabaseBuilder _builder;
        public AuthenticationsContext(IDatabaseBuilder builder)
        {
            _builder = builder;
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_builder != null)
                _builder.OnConfiguring(optionsBuilder);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(model =>
            {
                model.HasKey(x => x.Id);
                model.HasIndex(u => u.UserName)
                .IsUnique();
            });

        }
    }
}