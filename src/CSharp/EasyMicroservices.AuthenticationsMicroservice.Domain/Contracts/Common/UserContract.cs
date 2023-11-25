using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class UserContract : IUniqueIdentitySchema, ISoftDeleteSchema, IDateTimeSchema
    {
        public long Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UniqueIdentity { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime? ModificationDateTime { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateTime { get; set; }
        public bool IsUsernameVerified { get; set; }
    }
}
