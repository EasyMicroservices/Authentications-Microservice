using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Responses;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.Helpers;
using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : SimpleQueryServiceController<UserEntity, AddUserRequestContract, UserContract, UserContract, long>
    {
        private readonly IContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long> _contractLogic;
        private readonly IJWTManager _jwtManager;

        public UsersController(IContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract, long> contractLogic, IJWTManager jwtManager) : base(contractLogic)
        {
            _contractLogic = contractLogic;
            _jwtManager = jwtManager;
        }
        [HttpPost]
        public async Task<MessageContract<bool>> VerifyUserName(VerifyEmailAddressContract request)
        {
            var user = await _contractLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long> { Id = request.UserId });
            if (user.IsSuccess)
            {
                var updateUser = await _contractLogic.Update(new UserContract
                {
                    CreationDateTime = user.Result.CreationDateTime,
                    DeletedDateTime = user.Result.DeletedDateTime,
                    Id = user.Result.Id,
                    IsDeleted = user.Result.IsDeleted,
                    IsUsernameVerified = true,
                    ModificationDateTime = user.Result.ModificationDateTime,
                    Password = user.Result.Password,
                    UniqueIdentity = user.Result.UniqueIdentity,
                    UserName = user.Result.UserName,
                });
                if (!updateUser.IsSuccess)
                    return (FailedReasonType.Incorrect, "An error has occurred");
                return true;
            }
            return (FailedReasonType.Incorrect, "UserId is incorrect");
        }
        [HttpPost]
        public async Task<MessageContract<long>> Register(AddUserRequestContract request)
        {
            var response = await _jwtManager.Register(request);

            return response;
        }

        [HttpPost]
        public async Task<MessageContract<long>> Login(UserSummaryContract request)
        {
            string password = await AuthenticationHelper.HashPassword(request.Password);
            request.Password = password;

            var response = await _jwtManager.Login(request);

            return response;
        }


        [HttpPost]
        public async Task<MessageContract<UserResponseContract>> GenerateToken(UserClaimContract request)
        {
            string password = await AuthenticationHelper.HashPassword(request.Password);
            request.Password = password;

            var response = await _jwtManager.GenerateToken(request);

            return response;
        }

        [HttpPost]
        public async Task<MessageContract<UserResponseContract>> RegenerateToken(RegenerateTokenContract request)
        {
            var user = await _contractLogic.GetById(new Cores.Contracts.Requests.GetIdRequestContract<long>
            {
                Id = request.UserId
            });

            if (user)
            {

                string password = user.Result.Password;

                var req = new UserClaimContract
                {
                    Password = password,
                    UserName = user.Result.UserName,
                    Claims = request.Claims
                };

                var response = await _jwtManager.GenerateToken(req);

                return new UserResponseContract
                {
                    Token = response.Result.Token
                };
            }

            return user.ToContract<UserResponseContract>();
        }

        [HttpGet]
        [Authorize]
        public string Test()
        {
            return "test";
        }

    }
}
