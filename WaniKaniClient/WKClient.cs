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
            #warning Remove this when done
            //return JObject.Parse(File.ReadAllText("text.txt"));

            WebClient httpClient = new WebClient();

            string responce = httpClient.DownloadString(BuildUrl(resource, optionalArgument));

            #warning Remove this when done
            File.WriteAllText("text.txt", responce); //Temporare Solution to not ask server to much.

            return JObject.Parse(responce);
        }

        public UserInformation UserInformation
        {
            get
            {
                JObject responce = Request("user-information");

                var requestData = responce["user_information"];

                return JsonConvert.DeserializeObject<UserInformation>(requestData.ToString());
            }
        }

        public StudyQueue StudyQueue
        {
            get
            {
                JObject responce = Request("study-queue");

                var requestData = responce["requested_information"];

                return JsonConvert.DeserializeObject<StudyQueue>(requestData.ToString());
            }
        }


    }
}
