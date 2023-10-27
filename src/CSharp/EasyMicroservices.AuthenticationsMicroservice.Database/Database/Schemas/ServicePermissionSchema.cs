using EasyMicroservices.AuthenticationsMicroservice.DataTypes;
using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class ServicePermissionSchema : FullAbilitySchema
    {
        public string MicroserviceName { get; set; }
        public string ServiceName { get; set; }
        public string MethodName { get; set; }
        public AccessPermissionType AccessType { get; set; } = AccessPermissionType.Granted;
    }
}
