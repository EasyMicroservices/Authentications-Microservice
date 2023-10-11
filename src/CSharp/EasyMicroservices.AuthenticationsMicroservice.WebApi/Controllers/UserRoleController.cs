using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class UserRoleController : SimpleQueryServiceController<UserRoleEntity, AddUserRoleRequestContract, UserRoleContract, UserRoleContract, long>
    {
        public UserRoleController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
