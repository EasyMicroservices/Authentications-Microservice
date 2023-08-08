using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EasyMicroservices.AuthenticationsMicroservice.Contracts.Requests
{
    public class UserAddRequestContract : UserContract
    {
        [BindNever]
        [JsonIgnore]
        public long Id { get; set; }

        [BindNever]
        [JsonIgnore]
        public string UniqueIdentity { get; set; }
    }
}
