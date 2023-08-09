using System.Collections.Generic;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class UserClaimContract : UserSummaryContract
    {
        public List<ClaimContract> Claims { get; set; }
    }
}
