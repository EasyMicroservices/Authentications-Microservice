namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class RoleParentChildEntity
    {
        public long ChildId { get; set; }
        public long ParentId { get; set; }

        public RoleEntity Child { get; set; }
        public RoleEntity Parent { get; set; }
    }
}
