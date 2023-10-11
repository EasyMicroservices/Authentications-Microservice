using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class RoleSchema : FullAbilitySchema
    {
        public string Name { get; set; }
    }
}
