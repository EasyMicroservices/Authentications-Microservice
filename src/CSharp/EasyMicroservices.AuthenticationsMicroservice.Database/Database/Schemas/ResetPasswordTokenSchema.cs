using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class ResetPasswordTokenSchema : FullAbilitySchema
    {
        public string Token { get; set; }
        public bool HasConsumed { get; set; }
        public DateTime ExpirationDateTime { get; set; }
    }
}
