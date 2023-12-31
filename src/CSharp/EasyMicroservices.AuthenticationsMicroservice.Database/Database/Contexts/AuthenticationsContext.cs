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
            modelBuilder.Entity<UserEntity>(model =>
            {
                model.HasIndex(u => new { u.BusinessUniqueIdentity, u.UserName })
                .IsUnique();
            });

            modelBuilder.Entity<RoleServicePermissionEntity>(model =>
            {
                model.HasKey(u => new { u.RoleId, u.ServicePermissionId });
            });

            modelBuilder.Entity<UserRoleEntity>(model =>
            {
                model.HasKey(u => new { u.RoleId, u.UserId });
            });

            modelBuilder.Entity<ServicePermissionEntity>(model =>
            {
                model.HasIndex(u => u.MicroserviceName);
                model.HasIndex(u => u.ServiceName);
                model.HasIndex(u => u.MethodName);
                model.HasIndex(u => new { u.MicroserviceName, u.ServiceName, u.MethodName }).IsUnique();
            });

            modelBuilder.Entity<RoleParentChildEntity>(model =>
            {
                model.HasKey(u => new { u.ParentId, u.ChildId });

                model.HasOne(u => u.Parent)
                .WithMany(u => u.Parents)
                .HasForeignKey(u => u.ParentId)
                .OnDelete(DeleteBehavior.Restrict);

                model.HasOne(u => u.Child)
                .WithMany(u => u.Children)
                .HasForeignKey(u => u.ChildId)
                .OnDelete(DeleteBehavior.Restrict);
            });

            var result = base.AutoModelCreating(modelBuilder);
            AllSeedData.Seed(modelBuilder);
        }
    }
}