using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Contracts.Requests;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class RoleController : SimpleQueryServiceController<RoleEntity, AddRoleRequestContract, RoleContract, RoleContract, long>
    {
        public RoleController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ListMessageContract<RoleContract>> GetRolesByUserId(GetIdRequestContract<long> request)
        {
            var result = await UnitOfWork.GetLongLogic<UserRoleEntity>()
                .GetAll(q => q.Include(x => x.User)
                .Include(x => x.Role)
                .Where(x => x.UserId == request.Id))
                .AsCheckedResult();

            return UnitOfWork.GetMapper().MapToList<RoleContract>(result.Select(x => x.Role));
        }
    }
}