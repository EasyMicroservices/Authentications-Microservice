using EasyMicroservices.Cores.Database.Interfaces;
using EasyMicroservices.Cores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Database.Schemas
{
    public class CommentSchema : IUniqueIdentitySchema
    {
        public string Name { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime ModifiationDateTime { get; set; }
        public string UniqueIdentity { get; set; }
    }
}
