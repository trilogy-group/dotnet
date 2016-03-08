using Newtonsoft.Json;
using System;
using System.IO;

namespace Structurizr.IO.Json
{
    public class JsonWriter
    {

        public bool IndentOutput { get; set; }

        public JsonWriter(bool indentOutput)
        {
            this.IndentOutput = indentOutput;
        }

        public void Write(Workspace workspace, StringWriter writer)
        {
            String json = JsonConvert.SerializeObject(workspace,
                IndentOutput == true ? Formatting.Indented : Formatting.None,
                new Newtonsoft.Json.Converters.StringEnumConverter());

            writer.WriteLine(json);
        }

    }
}
