using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class RoleServicePermissionController : SimpleQueryServiceController<RoleServicePermissionEntity, AddRoleServicePermissionRequestContract, RoleServicePermissionContract, RoleServicePermissionContract, long>
    {
        public RoleServicePermissionController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
