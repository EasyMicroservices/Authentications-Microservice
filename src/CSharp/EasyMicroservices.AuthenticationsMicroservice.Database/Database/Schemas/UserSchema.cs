using EasyMicroservices.Cores.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class UserSchema : FullAbilitySchema
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsVerified { get; set; }
    }
}
