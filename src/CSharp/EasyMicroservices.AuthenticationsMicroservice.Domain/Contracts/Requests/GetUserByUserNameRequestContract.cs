using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class GetUserByUserNameRequestContract : IUniqueIdentitySchema
    {
        public string UserName { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
