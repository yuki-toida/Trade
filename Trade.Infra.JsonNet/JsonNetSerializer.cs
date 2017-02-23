using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Trade.Infra.Contract.Serialization.Json;

namespace Trade.Infra.JsonNet
{
    public class JsonNetSerializer : IJsonSerializer
    {
        public string Serialize(object obj) => JsonConvert.SerializeObject(obj, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        public object Deserialize(string json) => JsonConvert.DeserializeObject(json, new JsonSerializerSettings()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        });

        public T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public object Deserialize(string json, Type type) => JsonConvert.DeserializeObject(json, type);
    }
}
