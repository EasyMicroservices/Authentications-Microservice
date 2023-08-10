using EasyMicroservices.AuthenticationsMicroservice.Contracts;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Responses;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Claims;
using System.Text;
using EasyMicroservices.ServiceContracts;

namespace EasyMicroservices.AuthenticationsMicroservice.Interfaces
{
    public interface IJWTManager
    {
        Task<MessageContract<long>> Register(AddUserRequestContract input);
        Task<MessageContract<long>> Login(UserSummaryContract cred); 
        Task<MessageContract<UserResponseContract>> GenerateToken(UserClaimContract cred); 

    }
}