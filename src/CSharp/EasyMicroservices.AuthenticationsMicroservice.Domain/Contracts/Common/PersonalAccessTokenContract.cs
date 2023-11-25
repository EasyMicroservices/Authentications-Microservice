using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class PersonalAccessTokenContract : FullAbilityIdSchema<long>
    {
        public string Value { get; set; }
    }
}
