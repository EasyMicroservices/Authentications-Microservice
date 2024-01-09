using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.SeedData;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Builders;

public class AuthenticationDatabaseBuilder
{
    public void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserEntity>(model =>
        {
            model.HasIndex(u => new { u.BusinessUniqueIdentity, u.UserName })
            .IsUnique();
            model.ToTable("Users");
        });

        modelBuilder.Entity<RoleServicePermissionEntity>(model =>
        {
            model.HasKey(u => new { u.RoleId, u.ServicePermissionId });
            model.ToTable("RoleServicePermissions");
        });

        modelBuilder.Entity<UserRoleEntity>(model =>
        {
            model.HasKey(u => new { u.RoleId, u.UserId });
            model.ToTable("UserRoles");
        });

        modelBuilder.Entity<ServicePermissionEntity>(model =>
        {
            model.HasIndex(u => u.MicroserviceName);
            model.HasIndex(u => u.ServiceName);
            model.HasIndex(u => u.MethodName);
            model.HasIndex(u => new { u.MicroserviceName, u.ServiceName, u.MethodName }).IsUnique();
            model.ToTable("ServicePermissions");
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
            model.ToTable("RoleParentChildren");
        });

        modelBuilder.Entity<RoleEntity>(model =>
        {
            model.ToTable("Roles");
        });

        modelBuilder.Entity<PersonalAccessTokenEntity>(model =>
        {
            model.ToTable("PersonalAccessTokens");
        });

        modelBuilder.Entity<RegisterUserDefaultRoleEntity>(model =>
        {
            model.ToTable("RegisterUserDefaultRoles");
        });

        var result = new RelationalCoreModelBuilder().AutoModelCreating(modelBuilder);
    }
}
