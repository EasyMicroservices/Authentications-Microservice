using EasyMicroservices.AuthenticationsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System.Collections.Generic;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class RoleEntity : RoleSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public long? ParentId { get; set; }
        public RoleEntity Parent { get; set; }
        public ICollection<RoleEntity> Children { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; }
        public ICollection<RoleServicePermissionEntity> RoleServicePermissions { get; set; }
    }
}
