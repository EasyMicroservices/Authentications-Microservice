using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Responses;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
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
    public class UsersController : SimpleQueryServiceController<UserEntity, AddUserRequestContract, UpdateUserRequestContract, UserContract, long>
    {
        private readonly IContractLogic<UserEntity, AddUserRequestContract, UpdateUserRequestContract, UserContract, long> _contractLogic;
        private readonly IJWTManager _jwtManager;

        public UsersController(IContractLogic<UserEntity, AddUserRequestContract, UpdateUserRequestContract, UserContract, long> contractLogic, IJWTManager jwtManager) : base(contractLogic)
        {
            _contractLogic = contractLogic;
            _jwtManager = jwtManager;
        }

        [HttpPost]
        public async Task<MessageContract<UserResponseContract>> Register(AddUserRequestContract input)
        {
            string token = await _jwtManager.Register(input);

            if (token.IsNullOrEmpty())
                return (FailedReasonType.AccessDenied, "An error has occurred!");

            return new UserResponseContract {
                Token = token
            };
            
        }

        [HttpPost]

        public async Task<MessageContract<UserResponseContract>> Login(UserCredentialContract input)
        {
            string token = await _jwtManager.Login(input);

            if (token.IsNullOrEmpty())
                return (FailedReasonType.AccessDenied, "An error has occurred!");

            return new UserResponseContract {
                Token = token
            };
            
        }

    }
}
