using Newtonsoft.Json;
using System.IO;

namespace Structurizr.IO.Json
{
    public class JsonWriter : IWorkspaceWriter
    {

        public bool IndentOutput { get; set; }

        public JsonWriter(bool indentOutput)
        {
            this.IndentOutput = indentOutput;
        }

        public void Write(Workspace workspace, TextWriter writer)
        {
            string json = JsonConvert.SerializeObject(workspace,
                IndentOutput ? Formatting.Indented : Formatting.None,
                new Newtonsoft.Json.Converters.StringEnumConverter(),
                new PaperSizeJsonConverter());

            writer.Write(json);
        }

    }
}
