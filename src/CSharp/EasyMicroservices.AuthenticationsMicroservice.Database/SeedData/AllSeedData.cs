using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.Database.Schemas;
using Microsoft.EntityFrameworkCore;
using System;

namespace EasyMicroservices.AuthenticationsMicroservice.SeedData
{
    public static class AllSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<RoleEntity>()
                .HasData(FixDefaultValues(
                new RoleEntity()
                {
                    Id = 1,
                    Name = "Owner"
                },
                new RoleEntity()
                {
                    Id = 2,
                    Name = "SystemAdmin"
                },
                new RoleEntity()
                {
                    Id = 3,
                    Name = "SuperAdmin"
                },
                new RoleEntity()
                {
                    Id = 4,
                    Name = "HardWriter"
                },
                new RoleEntity()
                {
                    Id = 5,
                    Name = "Moderator"
                },
                new RoleEntity()
                {
                    Id = 6,
                    Name = "HardReader"
                },
                new RoleEntity()
                {
                    Id = 7,
                    Name = "Operator"
                },
                new RoleEntity()
                {
                    Id = 8,
                    Name = "EndUser"
                },
                new RoleEntity()
                {
                    Id = 9,
                    Name = "SoftWriter"
                },
                new RoleEntity()
                {
                    Id = 10,
                    Name = "SoftReader"
                }));
            modelBuilder
               .Entity<RoleParentChildEntity>()
               .HasData(FixDefaultValues(
                        new RoleParentChildEntity()
                        {
                            ChildId = 1,
                            ParentId = 2
                        }, new RoleParentChildEntity()
                        {
                            ChildId = 2,
                            ParentId = 3
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 2,
                            ParentId = 4
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 3,
                            ParentId = 5
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 3,
                            ParentId = 6
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 5,
                            ParentId = 7
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 5,
                            ParentId = 8
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 5,
                            ParentId = 9
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 5,
                            ParentId = 10
                        },
                        new RoleParentChildEntity()
                        {
                            ChildId = 2,
                            ParentId = 9
                        }));

            modelBuilder
                 .Entity<ServicePermissionEntity>()
                 .HasData(FixDefaultValues(
                 //owner full access
                 new ServicePermissionEntity()
                 {
                     Id = 1,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = null,
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 2,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "GetById",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 3,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "Filter",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 4,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "GetByUniqueIdentity",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 5,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "GetAllByUniqueIdentity",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 6,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "GetAll",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 7,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "Add",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 8,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "Update",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 9,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "SoftDeleteById",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 10,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "SoftDeleteBulkByIds",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 11,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "AddBulk",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 12,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "UpdateBulk",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 13,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "HardDeleteById",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 },
                 new ServicePermissionEntity()
                 {
                     Id = 14,
                     //any service
                     ServiceName = null,
                     //any method
                     MethodName = "HardDeleteBulkByIds",
                     //any microservice
                     MicroserviceName = null,
                     AccessType = DataTypes.AccessPermissionType.Granted
                 })
                 );
            modelBuilder
                .Entity<RoleServicePermissionEntity>()
                .HasData(FixDefaultValues(
                //owner full access
                new RoleServicePermissionEntity()
                {
                    Id = 1,
                    RoleId = 1,
                    ServicePermissionId = 1
                },
                //soft reader
                new RoleServicePermissionEntity()
                {
                    Id = 2,
                    RoleId = 10,
                    ServicePermissionId = 2
                },
                new RoleServicePermissionEntity()
                {
                    Id = 3,
                    RoleId = 10,
                    ServicePermissionId = 3
                },
                new RoleServicePermissionEntity()
                {
                    Id = 4,
                    RoleId = 10,
                    ServicePermissionId = 4
                },
                //hard reader
                new RoleServicePermissionEntity()
                {
                    Id = 5,
                    RoleId = 6,
                    ServicePermissionId = 5
                },
                new RoleServicePermissionEntity()
                {
                    Id = 6,
                    RoleId = 6,
                    ServicePermissionId = 6
                },
                //soft writer
                new RoleServicePermissionEntity()
                {
                    Id = 7,
                    RoleId = 9,
                    ServicePermissionId = 7
                },
                new RoleServicePermissionEntity()
                {
                    Id = 8,
                    RoleId = 9,
                    ServicePermissionId = 8
                },
                new RoleServicePermissionEntity()
                {
                    Id = 9,
                    RoleId = 9,
                    ServicePermissionId = 9
                },
                new RoleServicePermissionEntity()
                {
                    Id = 10,
                    RoleId = 9,
                    ServicePermissionId = 10
                },
                new RoleServicePermissionEntity()
                {
                    Id = 11,
                    RoleId = 9,
                    ServicePermissionId = 11
                },
                new RoleServicePermissionEntity()
                {
                    Id = 12,
                    RoleId = 9,
                    ServicePermissionId = 12
                },
                //hard writer
                new RoleServicePermissionEntity()
                {
                    Id = 13,
                    RoleId = 4,
                    ServicePermissionId = 13
                },
                new RoleServicePermissionEntity()
                {
                    Id = 14,
                    RoleId = 4,
                    ServicePermissionId = 14
                }));

            modelBuilder
                .Entity<UserEntity>()
                .HasData(FixDefaultValues(new UserEntity()
                {
                    Id = 1,
                    UserName = "Owner",
                    IsVerified = true
                }));

            modelBuilder
                .Entity<UserRoleEntity>()
                .HasData(FixDefaultValues(new UserRoleEntity()
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = 1
                }));

            modelBuilder
                .Entity<PersonalAccessTokenEntity>()
                .HasData(FixDefaultValues(new PersonalAccessTokenEntity()
                {
                    Id = 1,
                    UserId = 1,
                    Value = "ownerpat"
                }));
        }

        static T[] FixDefaultValues<T>(params T[] values)
            where T : FullAbilitySchema
        {
            foreach (var item in values)
            {
                item.CreationDateTime = DateTime.Now;
            }
            return values;
        }
    }
}
