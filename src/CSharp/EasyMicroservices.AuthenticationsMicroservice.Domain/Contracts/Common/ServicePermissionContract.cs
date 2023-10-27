using EasyMicroservices.AuthenticationsMicroservice.DataTypes;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class ServicePermissionContract
    {
        public string MicroserviceName { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public AccessPermissionType AccessType { get; set; } = AccessPermissionType.Granted;
    }
}
