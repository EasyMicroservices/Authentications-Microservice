using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class RoleServicePermissionEntity : FullAbilityIdSchema<long>
    {
        public long RoleId { get; set; }
        public long ServicePermissionId { get; set; }

        public RoleEntity Role { get; set; }
        public ServicePermissionEntity ServicePermission { get; set; }
    }
}
