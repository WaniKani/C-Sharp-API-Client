using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaniKaniClientLib.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WaniKaniClientLib.JsonHelpers;

namespace WaniKaniClientLib
{
    public class WaniKaniClient
    {
        public string APIKey { get; private set; }
        public static readonly string ApiVersion = "v1.1";
        public int CacheInMinutes { get; set; }

        private UserInformation _cachedUserInformation;
        private DateTime _cachedTimeUserInformation;
        private StudyQueue _cachedStudyQueue;
        private DateTime _cachedTimeStudyQueue;
        private LevelProgression _cachedLevelProgression;
        private DateTime _cachedTimeLevelProgression;
        private SrsDistribution _cachedSrsDistribution;
        private DateTime _cachedTimeSrsDistribution;


        public WaniKaniClient(string apiKey, int cacheInMinutes = 15)
        {
            APIKey = apiKey;
            CacheInMinutes = cacheInMinutes;
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
                if (_cachedUserInformation != null && _cachedTimeUserInformation > DateTime.Now)
                    return _cachedUserInformation;

                JObject responce = Request("user-information");
                UpdateUserInformation(responce);

                return _cachedUserInformation;
            }
        }

        private void UpdateUserInformation(JObject responce)
        {
            var requestData = responce["user_information"];
            _cachedUserInformation = JsonConvert.DeserializeObject<UserInformation>(requestData.ToString());

            _cachedTimeUserInformation = DateTime.Now.AddMinutes(CacheInMinutes);
        }

        public StudyQueue StudyQueue
        {
            get
            {
                if (_cachedStudyQueue != null && _cachedTimeStudyQueue > DateTime.Now)
                    return _cachedStudyQueue;

                JObject responce = Request("study-queue");
                UpdateUserInformation(responce);

                var requestData = responce["requested_information"];

                _cachedStudyQueue =  JsonConvert.DeserializeObject<StudyQueue>(requestData.ToString());
                
                return _cachedStudyQueue;
            }
        }

        public LevelProgression LevelProgression
        {
            get
            {
                if (_cachedLevelProgression != null && _cachedTimeLevelProgression > DateTime.Now)
                    return _cachedLevelProgression;

                JObject responce = Request("level-progression");
                UpdateUserInformation(responce);

                var requestData = responce["requested_information"];

                _cachedLevelProgression = JsonConvert.DeserializeObject<LevelProgression>(requestData.ToString());

                return _cachedLevelProgression;
            }
        }

        public SrsDistribution SrsDistribution
        {
            get
            {
                if (_cachedSrsDistribution != null && _cachedTimeSrsDistribution > DateTime.Now)
                    return _cachedSrsDistribution;

                JObject responce = Request("srs-distribution");
                UpdateUserInformation(responce);

                var requestData = responce["requested_information"];

                _cachedSrsDistribution =  JsonConvert.DeserializeObject<SrsDistribution>(requestData.ToString());
                return _cachedSrsDistribution;
            }
        }

        /// <summary>
        /// Returns a list of the recent unlocks, Warning this one is not cached due it takes parameters, if you want to keep this information
        /// Cache it yourself.
        /// </summary>
        /// <param name="take">The number of recent unlocks, Max is 100</param>
        /// <returns>Returns a list of Character information.</returns>
        public List<BaseCharacter> RecentUnlocks(int take = 10)
        {
            if (take > 100)
                take = 100;

            JObject responce = Request("recent-unlocks", take.ToString());
            UpdateUserInformation(responce);

            var requestData = responce["requested_information"];

            return JsonConvert.DeserializeObject<List<BaseCharacter>>(requestData.ToString(), new CharacterTypeCreationConverter());
        }

    }
}
