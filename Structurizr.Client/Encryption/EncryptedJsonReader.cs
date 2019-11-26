using Newtonsoft.Json;
using Structurizr.IO.Json;
using System.IO;
using System.Threading.Tasks;

namespace Structurizr.Encryption
{
    public class EncryptedJsonReader
    {

        public async Task<EncryptedWorkspace> ReadAsync(StringReader reader)
        {
            EncryptedWorkspace workspace = JsonConvert.DeserializeObject<EncryptedWorkspace>(
                await reader.ReadToEndAsync(),
                new Newtonsoft.Json.Converters.StringEnumConverter(),
                new PaperSizeJsonConverter(),
                new EncryptionStrategyJsonConverter());

            return workspace;
        }

    }
}
