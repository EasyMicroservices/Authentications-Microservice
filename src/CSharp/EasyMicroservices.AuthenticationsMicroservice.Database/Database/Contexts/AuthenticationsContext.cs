using EasyMicroservices.AuthenticationsMicroservice.Database.Builders;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.SeedData;
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
        public DbSet<RoleParentChildEntity> RoleParentChildren { get; set; }
        public DbSet<PersonalAccessTokenEntity> PersonalAccessTokens { get; set; }
        public DbSet<RegisterUserDefaultRoleEntity> RegisterUserDefaultRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new AuthenticationDatabaseBuilder().OnModelCreating(modelBuilder);
            var result = base.AutoModelCreating(modelBuilder);
            AuthenticationsSeedData.Seed(modelBuilder);
        }
    }
}