using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Common
{
    public class RoleServicePermissionContract
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public long ServicePermissionId { get; set; }
    }
}
