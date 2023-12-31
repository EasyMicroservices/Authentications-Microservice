using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class UserSchema : FullAbilitySchema
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        /// <summary>
        /// each username is unique by UniqueIdentity : 1-2, 1-3
        /// </summary>
        public string BusinessUniqueIdentity { get; set; }

        public bool IsVerified { get; set; }
    }
}
