using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaniKaniClient.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace WaniKaniClient
{
    public class WKClient
    {
        public string APIKey { get; private set; }
        public static readonly string ApiVersion = "v1.1";

        public WKClient(string apiKey)
        {
            APIKey = apiKey;
        }

        private string BuildUrl(string resource = null, string optionalArgument = null)
        {
            string url = "http://www.wanikani.com/api/" + ApiVersion + "/user/" + APIKey + "/";

            if (resource != null)
                url += resource + "/";

            if (optionalArgument != null)
                url += optionalArgument + "/";

            return url;
        }

        private JObject Request(string resource = null, string optionalArgument = null)
        {
            return JObject.Parse(File.ReadAllText("text.txt"));

            WebClient httpClient = new WebClient();

            string responce = httpClient.DownloadString(BuildUrl(resource, optionalArgument));
            File.WriteAllText("text.txt", responce); //Temporare Solution to not ask server to much.

            return JObject.Parse(responce);
        }

        public UserInformation GetUserInformation()
        {
            //responce = 
            //

            JObject responce = Request();

            var someData = responce["user_information"];

            return JsonConvert.DeserializeObject<UserInformation>(someData.ToString());
        }

    }
}
