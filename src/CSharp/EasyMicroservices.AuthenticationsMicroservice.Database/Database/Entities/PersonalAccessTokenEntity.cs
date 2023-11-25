using EasyMicroservices.AuthenticationsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class PersonalAccessTokenEntity : PersonalAccessTokenSchema, IIdSchema<long>
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
