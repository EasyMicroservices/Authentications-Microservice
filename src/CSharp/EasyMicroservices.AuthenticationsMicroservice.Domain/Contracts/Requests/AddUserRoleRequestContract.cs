namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class AddUserRoleRequestContract
    {
        public long RoleId { get; set; }
        public long UserId { get; set; }
    }
}
