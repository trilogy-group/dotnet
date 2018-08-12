using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace Structurizr.IO.Json
{
    public class JsonReader
    {

        public Workspace Read(StringReader reader)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                Converters = new List<JsonConverter> {
                    new Newtonsoft.Json.Converters.StringEnumConverter(),
                    new PaperSizeJsonConverter()
                }
            };

            Workspace workspace = JsonConvert.DeserializeObject<Workspace>(reader.ReadToEnd(), settings);
            workspace.Hydrate();

            return workspace;
        }

    }
}
