using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Responses;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.Helpers;
using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using EasyMicroservices.Cores.AspEntityFrameworkCoreApi.Interfaces;
using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice
{
    public class JWTManager : IJWTManager
    {
        private readonly IConfiguration _config;
        private readonly IUnitOfWork _unitOfWork;

        public JWTManager(IUnitOfWork unitOfWork, IConfiguration config)
        {
            _config = config;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<MessageContract<long>> Login(UserSummaryContract cred)
        {
            var logic = _unitOfWork.GetLongContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract>();
            var userRecords = await logic.GetAll();
            var user = userRecords.Result.Where(x => x.UserName == cred.UserName && x.Password == cred.Password);
            if (!user.Any())
                return (FailedReasonType.AccessDenied, "Username or password is invalid."); //"Username or password is invalid."


            return user.FirstOrDefault().Id;
        }

        public virtual async Task<MessageContract<UserResponseContract>> GenerateToken(UserClaimContract cred)
        {
            var response = await Login(cred);
            if (!response)
                return response.ToContract<UserResponseContract>();

            var logic = _unitOfWork.GetLongContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract>();
            var user = await logic.GetBy(x => x.UserName == cred.UserName && x.Password == cred.Password);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.GetValue<string>("JWT:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(cred.Claims.Select(x => new Claim(x.Name, x.Value)).ToArray()),
                Expires = DateTime.UtcNow.AddSeconds(_config.GetValue<int>("JWT:TokenExpireTimeInSeconds")),
                Issuer = _config.GetValue<string>("JWT:Issuer"),
                Audience = _config.GetValue<string>("JWT:Audience"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new UserResponseContract
            {
                Token = tokenString,
                UniqueIdentity = user.Result.UniqueIdentity
            };
        }


        public virtual async Task<MessageContract<long>> Register(AddUserRequestContract input)
        {
            string Password = input.Password;
            input.Password = await AuthenticationHelper.HashPassword(input.Password);

            var logic = _unitOfWork.GetLongContractLogic<UserEntity, AddUserRequestContract, UserContract, UserContract>();
            var usersRecords = await logic.GetBy(x => x.UserName == input.UserName.ToLower());

            if (usersRecords.IsSuccess)
                return (FailedReasonType.Duplicate, "User already exists!");

            var user = await logic.Add(input);

            return user;
        }
    }
}
