using EasyMicroservices.AuthenticationsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System.Collections.Generic;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class ServicePermissionEntity : ServicePermissionSchema, IIdSchema<long>
    {
        public long Id { get; set; }
        public ICollection<RoleServicePermissionEntity> RoleServicePermissions { get; set; }
    }
}
