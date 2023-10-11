namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class AddRoleRequestContract
    {
        public string Name { get; set; }
        public long? ParentId { get; set; }
    }
}
