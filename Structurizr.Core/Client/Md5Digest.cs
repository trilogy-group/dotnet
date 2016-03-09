using System.Security.Cryptography;
using System.Text;

namespace Structurizr.Client
{
    internal class Md5Digest
    {

        internal string Generate(string content)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] textToHash = Encoding.Default.GetBytes(content);
            byte[] result = md5.ComputeHash(textToHash);

            StringBuilder buf = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                buf.Append(result[i].ToString("x2"));
            }

            return buf.ToString();
        }

    }
}
