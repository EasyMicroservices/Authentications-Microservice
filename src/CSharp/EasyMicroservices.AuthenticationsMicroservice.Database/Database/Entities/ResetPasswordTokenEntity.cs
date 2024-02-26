using EasyMicroservices.Cores.Interfaces;
using EasyMicroservices.AuthenticationsMicroservice.Database.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class ResetPasswordTokenEntity : ResetPasswordTokenSchema, IIdSchema<long>
    {
        public long Id { get; set; }
    }
}
