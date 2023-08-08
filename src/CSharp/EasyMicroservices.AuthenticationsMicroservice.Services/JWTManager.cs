using EasyMicroservices.AuthenticationsMicroservice.Contracts;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.AuthenticationsMicroservice.Interfaces;
using EasyMicroservices.Cores.Database.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        private readonly IContractLogic<UserEntity, UserAddRequestContract, UserUpdateRequest, UserContract, long> _userLogic;

        public JWTManager(IContractLogic<UserEntity, UserAddRequestContract, UserUpdateRequest, UserContract, long> userLogic, IConfiguration config)
        {
            _config = config;
            _userLogic = userLogic;
        }

        public virtual async Task<string> Authenticate(UserAuthInputContract cred)
        {
             var usersRecords = await _userLogic.GetAll();
             var user = usersRecords.Result.Where(x => x.UserName == cred.UserName && x.Password == cred.Password);
             UserContract userData = new();

            if (!user.Any())
                return null;
            else
                userData = user.FirstOrDefault();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config.GetValue<string>("JWT:Key"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Name, userData.Id.ToString()),
                }),
                Expires = DateTime.UtcNow.AddSeconds(_config.GetValue<int>("JWT:TokenExpireTimeInSeconds")),
                Issuer = _config.GetValue<string>("JWT:Issuer"),
                Audience = _config.GetValue<string>("JWT:Audience"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
       }

        public virtual async Task<string> Register(UserAddRequestContract input)
        {
            string Password = input.Password;

            var usersRecords = await _userLogic.GetAll();
            var IfUserNameAlreadyExist = usersRecords.Result.Any(x => x.UserName == input.UserName.ToLower());
            
            if (IfUserNameAlreadyExist)
                return null;

            var user = await _userLogic.Add(input);

            string Token = await Authenticate(new UserAuthInputContract
            {
                UserName = input.UserName,
                Password = Password
            });

            if (Token.IsNullOrEmpty())
                return null;
            else
                return Token;
        }

    }
}
