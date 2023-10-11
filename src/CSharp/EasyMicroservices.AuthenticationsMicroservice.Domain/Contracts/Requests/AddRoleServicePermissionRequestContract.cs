using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class AddRoleServicePermissionRequestContract
    {
        public long RoleId { get; set; }
        public long ServicePermissionId { get; set; }
    }
}
