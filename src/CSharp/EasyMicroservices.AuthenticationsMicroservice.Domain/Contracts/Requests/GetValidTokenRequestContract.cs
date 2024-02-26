using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class GetValidTokenRequestContract
    {
        public string Token { get; set; }
    }
}
