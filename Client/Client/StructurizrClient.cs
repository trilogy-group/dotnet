using Structurizr.IO.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace Structurizr.Client
{
    public class StructurizrClient
    {

        private const string WorkspacePath = "/workspace/";

        public string Url { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }

        public StructurizrClient(string apiKey, string apiSecret)
        {
            this.ApiKey = apiKey;
            this.ApiSecret = apiSecret;
            this.Url = "https://api.structurizr.com";
        }

        public Workspace GetWorkspace(long workspaceId)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                { 
                    string httpMethod = "GET";
                    string path = WorkspacePath + workspaceId;

                    AddHeaders(webClient, httpMethod, path, "", "");

                    string response = webClient.DownloadString(this.Url + path);
                    System.Console.WriteLine(response);

                    // todo :-)
                    return new Workspace("Name", "Description");
                }
                catch (Exception e)
                {
                    throw new StructurizrClientException("There was an error getting the workspace: " + e.Message, e);
                }
            }
        }

        public void PutWorkspace(long workspaceId, Workspace workspace)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    string httpMethod = "PUT";
                    string path = WorkspacePath + workspaceId;

                    JsonWriter jsonWriter = new JsonWriter(false);
                    StringWriter stringWriter = new StringWriter();
                    jsonWriter.Write(workspace, stringWriter);
                    stringWriter.Flush();

                    string workspaceAsJson = stringWriter.ToString();

                    AddHeaders(webClient, httpMethod, path, workspaceAsJson, "application/json");

                    string response = webClient.UploadString(this.Url + path, httpMethod, workspaceAsJson);
                    System.Console.WriteLine(response);

                }
                catch (Exception e)
                {
                    throw new StructurizrClientException("There was an error putting the workspace: " + e.Message, e);
                }
            }
        }

        private void AddHeaders(WebClient webClient, string httpMethod, string path, string content, string contentType)
        {
            string contentMd5 = new Md5Digest().Generate(content);
            string contentMd5Base64Encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(contentMd5));
            string nonce = "" + getCurrentTimeInMilliseconds();

            HashBasedMessageAuthenticationCode hmac = new HashBasedMessageAuthenticationCode(ApiSecret);
            HmacContent hmacContent = new HmacContent(httpMethod, path, contentMd5, contentType, nonce);
            string authorizationHeader = new HmacAuthorizationHeader(ApiKey, hmac.Generate(hmacContent.ToString())).ToString();

            webClient.Headers.Add(HttpHeaders.Authorization, authorizationHeader);
            webClient.Headers.Add(HttpHeaders.Nonce, nonce);
            webClient.Headers.Add(HttpHeaders.ContentMd5, contentMd5Base64Encoded);
            webClient.Headers.Add(HttpHeaders.ContentType, contentType);
        }

        private long getCurrentTimeInMilliseconds()
        {
            DateTime Jan1st1970Utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return (long)(DateTime.UtcNow - Jan1st1970Utc).TotalMilliseconds;
        }

    }
}
