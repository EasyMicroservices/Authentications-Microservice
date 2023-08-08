using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class UserContract : IUniqueIdentitySchema
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
