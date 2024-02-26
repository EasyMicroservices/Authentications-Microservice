using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class ResetPasswordTokenContract
    {
        public long Id { get; set; }
        public string Token { get; set; }
        public string UniqueIdentity { get; set; }
        public bool HasConsumed { get; set; }
        public DateTime ExpirationDateTime { get; set; }
    }
}
