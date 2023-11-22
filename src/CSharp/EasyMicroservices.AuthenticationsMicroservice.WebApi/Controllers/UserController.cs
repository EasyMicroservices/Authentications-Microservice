using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Responses;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.Helpers;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class UsersController : SimpleQueryServiceController<UserEntity, AddUserRequestContract, UserContract, UserContract, long>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork) : base(unitOfWork)
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

 
    }
}
