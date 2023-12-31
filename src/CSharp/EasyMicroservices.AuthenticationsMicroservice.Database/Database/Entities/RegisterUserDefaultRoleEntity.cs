using EasyMicroservices.Cores.Database.Schemas;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities;
/// <summary>
/// give default role when user start register
/// it works with unique identity
/// </summary>
public class RegisterUserDefaultRoleEntity : FullAbilityIdSchema<long>
{
    public long RoleId { get; set; }
    public RoleEntity Role { get; set; }
}
