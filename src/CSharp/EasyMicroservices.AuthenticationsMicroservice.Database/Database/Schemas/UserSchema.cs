using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class UserSchema : IUniqueIdentitySchema
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public string UniqueIdentity { get; set; }
    }
}
