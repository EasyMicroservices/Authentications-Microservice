using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class AddUserRequestContract : IUniqueIdentitySchema
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
