using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class UserController : SimpleQueryServiceController<UserEntity, AddUserRequestContract, UserContract, UserContract, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<MessageContract<UserContract>> GetUserByUserName(GetUserByUserNameRequestContract request)
        {
            return await _unitOfWork.GetContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long>().GetBy(x => x.UserName == request.Username);
        }

        [HttpPost]
        public async Task<MessageContract<UserContract>> VerifyUserIdentity(UserSummaryContract request)
        {
            return await _unitOfWork.GetContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long>().GetBy(x => x.UserName == request.UserName && x.Password == request.Password);
        }

        [HttpPost]
        public async Task<MessageContract<UserContract>> GetUserByPersonalAccessToken(PersonalAccessTokenRequestContract request)
        {
            var result = await _unitOfWork.GetLongLogic<PersonalAccessTokenEntity>().GetBy(x => x.Value == request.Value
            , q => q.Include(x => x.User)).AsCheckedResult();

            return _unitOfWork.GetMapper().Map<UserContract>(result.User);
        }
    }
}
