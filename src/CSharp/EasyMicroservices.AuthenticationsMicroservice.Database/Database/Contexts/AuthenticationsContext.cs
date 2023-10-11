using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Intrerfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Contexts
{
    public class AuthenticationsContext : RelationalCoreContext
    {
        public AuthenticationsContext(IEntityFrameworkCoreDatabaseBuilder builder) : base(builder)
        {
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<UserRoleEntity> UserRoles { get; set; }
        public DbSet<ServicePermissionEntity> ServicePermissions { get; set; }
        public DbSet<RoleServicePermissionEntity> RoleServicePermissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.AutoModelCreating(modelBuilder);

            modelBuilder.Entity<UserEntity>(model =>
            {
                model.HasIndex(u => u.UserName)
                .IsUnique();
            });

            modelBuilder.Entity<ServicePermissionEntity>(model =>
            {
                model.HasIndex(u => u.MicroserviceName);
                model.HasIndex(u => u.ServiceName);
                model.HasIndex(u => u.MethodName);
                model.HasIndex(u => new { u.MicroserviceName, u.ServiceName, u.MethodName }).IsUnique();
            });
        }
    }
}