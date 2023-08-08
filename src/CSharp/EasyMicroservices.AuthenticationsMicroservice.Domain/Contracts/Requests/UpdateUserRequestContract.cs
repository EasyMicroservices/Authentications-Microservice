using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class UpdateUserRequestContract : UserContract
    {
        [BindNever]
        [JsonIgnore]
        public long UniqueIdentity { get; set; }
    }
}
