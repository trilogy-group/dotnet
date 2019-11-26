using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace Structurizr.IO.Json
{
    public class JsonReader
    {

        public async Task<Workspace> ReadAsync(StringReader reader)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
                Converters = new List<JsonConverter> {
                    new StringEnumConverter(),
                    new IsoDateTimeConverter(),
                    new PaperSizeJsonConverter()
                },
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };

            Workspace workspace = JsonConvert.DeserializeObject<Workspace>(await reader.ReadToEndAsync(), settings);
            workspace.Hydrate();

            return workspace;
        }

    }
}
