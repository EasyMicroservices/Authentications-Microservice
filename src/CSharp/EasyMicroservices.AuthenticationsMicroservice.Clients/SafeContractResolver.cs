using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Reflection;

namespace EasyMicroservices.CommentsMicroservice.Clients
{
    internal class SafeContractResolver : DefaultContractResolver
    {
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProp = base.CreateProperty(member, memberSerialization);
            jsonProp.Required = Required.Default;
            return jsonProp;
        }
    }

    internal class MyJsonSerializerSettings : JsonSerializerSettings
    {
        public MyJsonSerializerSettings(JsonSerializerSettings settings)
        {
            this.ContractResolver = new SafeContractResolver();
        }
    }
}
