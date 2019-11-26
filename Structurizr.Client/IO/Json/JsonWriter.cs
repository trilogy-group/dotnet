using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Converters;
using System.Threading.Tasks;

namespace Structurizr.IO.Json
{
    public class JsonWriter
    {

        public bool IndentOutput { get; set; }

        public JsonWriter(bool indentOutput)
        {
            this.IndentOutput = indentOutput;
        }

        public async Task WriteAsync(Workspace workspace, TextWriter writer)
        {
            string json = JsonConvert.SerializeObject(workspace,
                IndentOutput ? Formatting.Indented : Formatting.None,
                new StringEnumConverter(),
                new IsoDateTimeConverter(),
                new PaperSizeJsonConverter());

            await writer.WriteAsync(json);
        }

    }
}
