using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class UserController : SimpleQueryServiceController<UserEntity, AddUserRequestContract, UserContract, UserContract, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public override async Task<MessageContract<long>> Add(AddUserRequestContract request, CancellationToken cancellationToken = default)
        {
            var userId = await base.Add(request, cancellationToken)
                .AsCheckedResult();

            var defaultRoles = await UnitOfWork.GetLogic<RegisterUserDefaultRoleEntity>()
                .GetAll(cancellationToken)
                .AsCheckedResult();

            if (defaultRoles.Count > 0)
            {
                var roles = await UnitOfWork.GetLogic<UserRoleEntity>().AddBulk(defaultRoles.Select(x => new UserRoleEntity()
                {
                    RoleId = x.RoleId,
                    UserId = userId,
                    UniqueIdentity = request.UniqueIdentity
                }).ToList()).AsCheckedResult();
            }
            return userId;
        }

        [HttpPost]
        public async Task<MessageContract<UserContract>> GetUserByUserName(GetUserByUserNameRequestContract request)
        {
            return await _unitOfWork.GetContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long>()
                .GetByUniqueIdentity(request,
                Cores.DataTypes.GetUniqueIdentityType.All,
                q => q.Where(x => x.UserName == request.UserName));
        }

        [HttpPost]
        public async Task<MessageContract<UserContract>> VerifyUserIdentity(UserSummaryContract request)
        {
            return await _unitOfWork.GetContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long>()
                .GetByUniqueIdentity(request,
                Cores.DataTypes.GetUniqueIdentityType.All,
                q => q.Where(x => x.UserName == request.UserName && x.Password == request.Password));
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<MessageContract<UserContract>> GetUserByPersonalAccessToken(PersonalAccessTokenRequestContract request)
        {
            var result = await _unitOfWork.GetLongLogic<PersonalAccessTokenEntity>().GetBy(x => x.Value == request.Value
            , q => q.Include(x => x.User)).AsCheckedResult();

            return _unitOfWork.GetMapper().Map<UserContract>(result.User);
        }
    }
}
