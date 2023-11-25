namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class AddPersonalAccessTokenRequestContract
    {
        public long UserId { get; set; }
        public string Value { get; set; }
    }
}
