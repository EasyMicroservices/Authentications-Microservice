namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class ServicePermissionContract
    {
        public string MicroserviceName { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
    }
}
