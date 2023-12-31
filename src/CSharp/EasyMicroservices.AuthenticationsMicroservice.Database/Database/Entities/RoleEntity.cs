using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System.Collections.Generic;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class RoleEntity : RoleSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public ICollection<RoleParentChildEntity> Parents { get; set; }
        public ICollection<RoleParentChildEntity> Children { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; }
        public ICollection<RoleServicePermissionEntity> RoleServicePermissions { get; set; }
        public ICollection<RegisterUserDefaultRoleEntity> RegisterUserDefaultRoles { get; set; }
    }
}
