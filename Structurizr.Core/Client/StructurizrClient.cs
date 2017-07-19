using Structurizr.Encryption;
using Structurizr.IO.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Structurizr.Client
{
    public class StructurizrClient
    {

        private const string WorkspacePath = "/workspace/";

        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        /// <summary>the location where a copy of the workspace will be archived when it is retrieved from the server</summary>
        public DirectoryInfo WorkspaceArchiveLocation { get; set; }

        public EncryptionStrategy EncryptionStrategy { get; set; }

        public bool MergeFromRemote { get; set; }

        public StructurizrClient(string apiKey, string apiSecret) : this("https://api.structurizr.com", apiKey, apiSecret)
        {
        }

        public StructurizrClient(string apiUrl, string apiKey, string apiSecret)
        {
            this.Url = apiUrl;
            this.ApiKey = apiKey;
            this.ApiSecret = apiSecret;

            this.WorkspaceArchiveLocation = new DirectoryInfo(".");
            this.MergeFromRemote = true;
        }

        public Workspace GetWorkspace(long workspaceId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string httpMethod = "GET";
                string path = WorkspacePath + workspaceId;

                AddHeaders(httpClient, httpMethod, new Uri(Url + path).AbsolutePath, "", "");

                var responseMessage = httpClient.GetAsync(Url + path);
                if (responseMessage.Result.StatusCode != HttpStatusCode.OK)
                {
                    throw new StructurizrClientException(responseMessage.Result.Content.ReadAsStringAsync().Result);
                }

                string response = responseMessage.Result.Content.ReadAsStringAsync().Result;
                ArchiveWorkspace(workspaceId, response);

                StringReader stringReader = new StringReader(response);
                if (EncryptionStrategy == null)
                {
                    return new JsonReader().Read(stringReader);
                }
                else
                {
                    EncryptedWorkspace encryptedWorkspace = new EncryptedJsonReader().Read(stringReader);
                    encryptedWorkspace.EncryptionStrategy.Passphrase = this.EncryptionStrategy.Passphrase;
                    return encryptedWorkspace.Workspace;
                }
            }
        }

        public void PutWorkspace(long workspaceId, Workspace workspace)
        {
            if (workspace == null)
            {
                throw new ArgumentException("A workspace must be supplied");
            }
            else if (workspaceId <= 0)
            {
                throw new ArgumentException("The workspace ID must be set");
            }

            if (MergeFromRemote)
            {
                Workspace remoteWorkspace = GetWorkspace(workspaceId);
                if (remoteWorkspace != null)
                {
                    workspace.Views.CopyLayoutInformationFrom(remoteWorkspace.Views);
                    workspace.Views.Configuration.CopyConfigurationFrom(remoteWorkspace.Views.Configuration);
                }
            }

            workspace.Id = workspaceId;

            using (HttpClient httpClient = new HttpClient())
            {
                try
                {
                    string httpMethod = "PUT";
                    string path = WorkspacePath + workspaceId;
                    string workspaceAsJson = "";

                    using (StringWriter stringWriter = new StringWriter())
                    {
                        if (EncryptionStrategy == null)
                        {
                            JsonWriter jsonWriter = new JsonWriter(false);
                            jsonWriter.Write(workspace, stringWriter);
                        }
                        else
                        {
                            EncryptedWorkspace encryptedWorkspace = new EncryptedWorkspace(workspace, EncryptionStrategy);
                            EncryptedJsonWriter jsonWriter = new EncryptedJsonWriter(false);
                            jsonWriter.Write(encryptedWorkspace, stringWriter);
                        }
                        stringWriter.Flush();
                        workspaceAsJson = stringWriter.ToString();
                        System.Console.WriteLine(workspaceAsJson);
                    }

                    AddHeaders(httpClient, httpMethod, new Uri(Url + path).AbsolutePath, workspaceAsJson, "application/json; charset=UTF-8");

                    HttpContent content = new StringContent(workspaceAsJson, Encoding.UTF8, "application/json");
                    content.Headers.ContentType.CharSet = "UTF-8";
                    string contentMd5 = new Md5Digest().Generate(workspaceAsJson);
                    string contentMd5Base64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(contentMd5));
                    content.Headers.ContentMD5 = Encoding.UTF8.GetBytes(contentMd5);
                    var response = httpClient.PutAsync(this.Url + path, content);
                    string responseContent = response.Result.Content.ReadAsStringAsync().Result;
                    System.Console.WriteLine(responseContent);
                }
                catch (Exception e)
                {
                    throw new StructurizrClientException("There was an error putting the workspace: " + e.Message, e);
                }
            }
        }

        private void AddHeaders(HttpClient httpClient, string httpMethod, string path, string content, string contentType)
        {
            string contentMd5 = new Md5Digest().Generate(content);
            string nonce = "" + getCurrentTimeInMilliseconds();

            HashBasedMessageAuthenticationCode hmac = new HashBasedMessageAuthenticationCode(ApiSecret);
            HmacContent hmacContent = new HmacContent(httpMethod, path, contentMd5, contentType, nonce);
            string authorizationHeader = new HmacAuthorizationHeader(ApiKey, hmac.Generate(hmacContent.ToString())).ToString();

            httpClient.DefaultRequestHeaders.Add(HttpHeaders.UserAgent, "structurizr-dotnet");
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(HttpHeaders.Authorization, authorizationHeader);
            httpClient.DefaultRequestHeaders.Add(HttpHeaders.Nonce, nonce);
        }

        private long getCurrentTimeInMilliseconds()
        {
            DateTime Jan1st1970Utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.UtcNow - Jan1st1970Utc).TotalMilliseconds;
        }

        private void ArchiveWorkspace(long workspaceId, string workspaceAsJson)
        {
            if (WorkspaceArchiveLocation != null)
            {
                File.WriteAllText(CreateArchiveFileName(workspaceId), workspaceAsJson);
            }
        }

        private string CreateArchiveFileName(long workspaceId)
        {
            return Path.Combine(
                WorkspaceArchiveLocation.FullName, 
                "structurizr-" + workspaceId + "-" + DateTime.UtcNow.ToString("yyyyMMddHHmmss") + ".json");
        }

    }
}
