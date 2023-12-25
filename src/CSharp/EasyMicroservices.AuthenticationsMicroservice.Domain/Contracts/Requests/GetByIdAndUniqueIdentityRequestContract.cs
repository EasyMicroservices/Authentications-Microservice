using EasyMicroservices.Cores.Interfaces;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests;
public class GetByIdAndUniqueIdentityRequestContract : IUniqueIdentitySchema
{
    public long Id { get; set; }
    public string UniqueIdentity { get; set; }
}
