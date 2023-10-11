using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class UserRoleEntity : FullAbilityIdSchema<long>
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }

        public RoleEntity Role { get; set; }
        public UserEntity User { get; set; }
    }
}
