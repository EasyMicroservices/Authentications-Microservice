using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class RoleController : SimpleQueryServiceController<RoleEntity, AddRoleRequestContract, RoleContract, RoleContract, long>
    {
        public RoleController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
