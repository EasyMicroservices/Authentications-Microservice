using EasyMicroservices.AuthenticationsMicroservice.Database.Schemas;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Entities
{
    public class UserEntity : UserSchema, IIdSchema<long>
    {
        public long Id { get; set; }
    }
}
