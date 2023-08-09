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
        public async Task<MessageContract<long>> Register(AddUserRequestContract request)
        {
            var response = await _jwtManager.Register(request);

            return response;
        }

        [HttpPost]

        public async Task<MessageContract<UserResponseContract>> Login(UserClaimContract request)
        {
            var response = await _jwtManager.Login(request);

            return response;
        }

        [HttpGet]
        [Authorize]
        public string Test()
        {
            return "test";
        }

    }
}
