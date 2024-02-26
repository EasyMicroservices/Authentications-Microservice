using EasyMicroservices.AuthenticationsMicroservice.Contracts.Common;
using EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
using EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
using EasyMicroservices.Cores.AspCoreApi;
using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.ServiceContracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.WebApi.Controllers
{
    public class ResetPasswordTokenController : SimpleQueryServiceController<ResetPasswordTokenEntity, ResetPasswordTokenContract, ResetPasswordTokenContract, ResetPasswordTokenContract, long>
    {
        private readonly IBaseUnitOfWork _unitOfWork;
        public ResetPasswordTokenController(IBaseUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<MessageContract<ResetPasswordTokenContract>> GetValidToken(GetValidTokenRequestContract request)
        {
            return await _unitOfWork.GetContractLogic<ResetPasswordTokenEntity, ResetPasswordTokenContract, long>().GetBy(x => x.Token.Equals(request.Token) && !x.HasConsumed && !x.IsDeleted && x.ExpirationDateTime >= DateTime.Now);
        }
    }
}
