using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class UserContract
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
