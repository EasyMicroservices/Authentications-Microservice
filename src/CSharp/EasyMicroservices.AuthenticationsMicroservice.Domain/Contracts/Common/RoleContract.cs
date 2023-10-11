using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class RoleContract : FullAbilityIdSchema<long>
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
