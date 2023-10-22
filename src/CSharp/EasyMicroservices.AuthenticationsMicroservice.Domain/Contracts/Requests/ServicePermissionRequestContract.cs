namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    /// <summary>
    /// 
    /// </summary>
    public class ServicePermissionRequestContract
    {
        public string RoleName { get; set; }
        public string MicroserviceName { get; set; }
    }
}
