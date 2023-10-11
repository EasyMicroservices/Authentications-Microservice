namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class AddServicePermissionRequestContract
    {
        public string MicroserviceName { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
    }
}
