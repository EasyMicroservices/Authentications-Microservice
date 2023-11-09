using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Responses;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.Helpers;
using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
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
        //private readonly IJWTManager _jwtManager;

        public UsersController(IUnitOfWork unitOfWork/*, IJWTManager jwtManager*/) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            //_jwtManager = jwtManager;
        }

        [HttpPost]
        public async Task<MessageContract> UserHasExistsByUsername(UserHasExistsByUsernameRequestContract request)
        {
            return await _unitOfWork.GetContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long>().GetBy(x => x.UserName == request.Username);
        }
               
        [HttpPost]
        public async Task<MessageContract> VerifyUserIdentity(UserSummaryContract request)
        {
            return await _unitOfWork.GetContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long>().GetBy(x => x.UserName == request.UserName && x.Password == request.Password);
        }

        //[HttpPost]
        //public async Task<MessageContract<bool>> VerifyUserName(VerifyEmailAddressContract request)
        //{
        //    var logic = _unitOfWork.GetLongContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract>();
        //    var user = await logic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long> { Id = request.UserId }).AsCheckedResult();
        //    if (user.IsUsernameVerified)
        //        return true;

        //    await logic.Update(new UserContract
        //    {
        //        CreationDateTime = user.CreationDateTime,
        //        DeletedDateTime = user.DeletedDateTime,
        //        Id = user.Id,
        //        IsDeleted = user.IsDeleted,
        //        IsUsernameVerified = true,
        //        ModificationDateTime = user.ModificationDateTime,
        //        Password = user.Password,
        //        UniqueIdentity = user.UniqueIdentity,
        //        UserName = user.UserName,
        //    }).AsCheckedResult();

        //    return true;

        //}
        //[HttpPost]
        //public async Task<MessageContract<long>> Register(AddUserRequestContract request)
        //{
        //    return await _jwtManager.Register(request);
        //}

        //[HttpPost]
        //public async Task<MessageContract<long>> Login(UserSummaryContract request)
        //{
        //    string password = await AuthenticationHelper.HashPassword(request.Password);
        //    request.Password = password;

        //    var response = await _jwtManager.Login(request);

        //    return response;
        //}

        //[HttpPost]
        //public async Task<MessageContract<UserResponseContract>> GenerateToken(UserClaimContract request)
        //{
        //    string password = await AuthenticationHelper.HashPassword(request.Password);
        //    request.Password = password;

        //    var response = await _jwtManager.GenerateToken(request);

        //    return response;
        //}

        //[HttpPost]
        //public async Task<MessageContract<UserResponseContract>> RegenerateToken(RegenerateTokenContract request)
        //{
        //    var logic = _unitOfWork.GetLongContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract>();
        //    var user = await logic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
        //    {
        //        Id = request.UserId
        //    });

        //    if (user)
        //    {

        //        string password = user.Result.Password;

        //        var req = new UserClaimContract
        //        {
        //            Password = password,
        //            UserName = user.Result.UserName,
        //            Claims = request.Claims
        //        };

        //        var response = await _jwtManager.GenerateToken(req);

        //        return new UserResponseContract
        //        {
        //            Token = response.Result.Token
        //        };
        //    }

        //    return user.ToContract<UserResponseContract>();
        //}

        //[HttpGet]
        //[Authorize]
        //public string Test()
        //{
        //    return "test";
        //}

    }
}
