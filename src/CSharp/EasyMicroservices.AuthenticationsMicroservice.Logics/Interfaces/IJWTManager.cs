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

namespace EasyMicroservices.AuthenticationsMicroservice.Interfaces
{
    public interface IJWTManager
    {
        Task<string> Register(AddUserRequestContract input);
        Task<string> Login(UserSummaryContract cred); 
    }
}