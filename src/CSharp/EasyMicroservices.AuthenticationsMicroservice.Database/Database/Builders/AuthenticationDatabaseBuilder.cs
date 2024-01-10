using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Relational.EntityFrameworkCore.Builders;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Builders;

public class AuthenticationDatabaseBuilder
{
    public void OnModelCreating(ModelBuilder modelBuilder, string suffix = "", string prefix = "")
    {
        modelBuilder.Entity<UserEntity>(model =>
        {
            model.HasIndex(u => new { u.BusinessUniqueIdentity, u.UserName })
            .IsUnique();
            model.ToTable(GetTableName("Users", suffix, prefix));
        });

        modelBuilder.Entity<RoleServicePermissionEntity>(model =>
        {
            model.HasKey(u => new { u.RoleId, u.ServicePermissionId });
            model.ToTable(GetTableName("RoleServicePermissions", suffix, prefix));
        });

        modelBuilder.Entity<UserRoleEntity>(model =>
        {
            model.HasKey(u => new { u.RoleId, u.UserId });
            model.ToTable(GetTableName("UserRoles", suffix, prefix));
        });

        modelBuilder.Entity<ServicePermissionEntity>(model =>
        {
            model.HasIndex(u => u.MicroserviceName);
            model.HasIndex(u => u.ServiceName);
            model.HasIndex(u => u.MethodName);
            model.HasIndex(u => new { u.MicroserviceName, u.ServiceName, u.MethodName }).IsUnique();
            model.ToTable(GetTableName("ServicePermissions", suffix, prefix));
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
            model.ToTable(GetTableName("RoleParentChildren", suffix, prefix));
        });

        modelBuilder.Entity<RoleEntity>(model =>
        {
            model.ToTable(GetTableName("Roles", suffix, prefix));
        });

        modelBuilder.Entity<PersonalAccessTokenEntity>(model =>
        {
            model.ToTable(GetTableName("PersonalAccessTokens", suffix, prefix));
        });

        modelBuilder.Entity<RegisterUserDefaultRoleEntity>(model =>
        {
            model.ToTable(GetTableName("RegisterUserDefaultRoles", suffix, prefix));
        });

        var result = new RelationalCoreModelBuilder().AutoModelCreating(modelBuilder);
    }

    string GetTableName(string name, string suffix = "", string prefix = "")
    {
        return string.Concat(suffix, name, prefix);
    }
}
