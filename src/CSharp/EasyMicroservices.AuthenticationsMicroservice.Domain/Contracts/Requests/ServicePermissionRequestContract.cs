using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class ServicePermissionRequestContract : IUniqueIdentitySchema
    {
        public string RoleName { get; set; }
        public string MicroserviceName { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
