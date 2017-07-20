using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Structurizr.Encryption;
using System;
using System.Reflection;

namespace Structurizr.IO.Json
{
    internal class DocumentationJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(Documentation).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JObject item = JObject.Load(reader);
            string type = item["type"].Value<string>();
            if (type == "structurizr")
            {
                return item.ToObject<StructurizrDocumentation>();
            }
            else if (type == "arc42")
            {
                // todo
                return item.ToObject<StructurizrDocumentation>();
            }
            else if (type == "viewpoints-and-perspectives")
            {
                // todo
                return item.ToObject<StructurizrDocumentation>();
            }
            else
            {
                // default to the Structurizr documentation
                return item.ToObject<StructurizrDocumentation>();
            }
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException("This operation is not implemented");
        }
    }
}
