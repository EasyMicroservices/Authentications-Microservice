using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class PersonalAccessTokenSchema : FullAbilitySchema
    {
        public string Value { get; set; }
    }
}
