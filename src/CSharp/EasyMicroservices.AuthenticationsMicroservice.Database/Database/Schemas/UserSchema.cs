using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class UserSchema : IUniqueIdentitySchema
    {
        public string UniqueIdentity { get; set; }
    }
}
