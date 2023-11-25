using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class PersonalAccessTokenController : SimpleQueryServiceController<PersonalAccessTokenEntity, AddPersonalAccessTokenRequestContract, PersonalAccessTokenContract, PersonalAccessTokenContract, long>
    {
        public PersonalAccessTokenController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}