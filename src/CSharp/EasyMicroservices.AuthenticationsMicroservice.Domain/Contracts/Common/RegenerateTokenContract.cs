using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class RegenerateTokenContract
    {
        public long UserId { get; set; }
        public List<ClaimContract> Claims { get; set; } 
    }
}
