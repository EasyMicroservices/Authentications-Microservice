using EasyMicroservices.AuthenticationsMicroservice.Contracts;
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
    [Route("apiss/[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [ApiController]
    public class UsersController : SimpleQueryServiceController<UserEntity, UserAddRequestContract, UserUpdateRequest, UserContract, long>
    {
        private readonly IContractLogic<UserEntity, UserAddRequestContract, UserUpdateRequest, UserContract, long> _contractLogic;
        private readonly IJWTManager _jwtManager;

        public UsersController(IContractLogic<UserEntity, UserAddRequestContract, UserUpdateRequest, UserContract, long> contractLogic, IJWTManager jwtManager) : base(contractLogic)
        {
            _contractLogic = contractLogic;
            _jwtManager = jwtManager;
        }

        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost("Register")]
        public async Task<MessageContract<UserResponseContract>> Register(UserAddRequestContract input)
        {
            string token = await _jwtManager.Register(input);

            if (token.IsNullOrEmpty())
                return (FailedReasonType.AccessDenied, "An error has occurred!");

            return new UserResponseContract {
                Token = token
            };
            
        }


        [ApiExplorerSettings(IgnoreApi = false)]
        [HttpPost("Authenticate")]
        public async Task<MessageContract<UserResponseContract>> Authenticate(UserAuthInputContract input)
        {
            string token = await _jwtManager.Authenticate(input);

            if (token.IsNullOrEmpty())
                return (FailedReasonType.AccessDenied, "An error has occurred!");

            return new UserResponseContract {
                Token = token
            };
            
        }

    }
}
