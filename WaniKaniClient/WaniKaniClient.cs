using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WaniKaniClientLib.Models;
using System.Net;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using WaniKaniClientLib.JsonHelpers;

namespace WaniKaniClientLib
{
    public class WaniKaniClient
    {
        public string APIKey { get; private set; }
        public static readonly string ApiVersion = "v1.4";
        public int CacheInMinutes { get; set; }

        private UserInformation _cachedUserInformation;
        private DateTime _cachedTimeUserInformation;
        private StudyQueue _cachedStudyQueue;
        private DateTime _cachedTimeStudyQueue;
        private LevelProgression _cachedLevelProgression;
        private DateTime _cachedTimeLevelProgression;
        private SrsDistribution _cachedSrsDistribution;
        private DateTime _cachedTimeSrsDistribution;

        /// <summary>
        /// Creates the client object.
        /// </summary>
        /// <param name="apiKey">The users API key</param>
        /// <param name="cacheInMinutes">How many minutes you want requests to be cached, default is 15.</param>
        public WaniKaniClient(string apiKey, int cacheInMinutes = 15)
        {
            APIKey = apiKey;
            CacheInMinutes = cacheInMinutes;
        }

        /// <summary>
        /// Get user information, you get this information from every request you do so if your smart you don't request this information the first time.
        /// </summary>
        /// <param name="noCache">No cached results if set to true</param>
        /// <returns>UserInformation</returns>
        public UserInformation UserInformation(bool noCache = false)
        {
            if (!noCache && _cachedUserInformation != null && _cachedTimeUserInformation > DateTime.Now)
                return _cachedUserInformation;

            JObject responce = Request("user-information");
            UpdateUserInformation(responce);

            return _cachedUserInformation;
        }

        /// <summary>
        /// Retreives the StudyQueue, it contains information such as number of reviews left.
        /// </summary>
        /// <param name="noCache">No cached results if set to true</param>
        /// <returns>StudyQueue</returns>
        public StudyQueue StudyQueue(bool noCache = false)
        {
            if (!noCache && _cachedStudyQueue != null && _cachedTimeStudyQueue > DateTime.Now)
                return _cachedStudyQueue;

            JObject responce = Request("study-queue");
            UpdateUserInformation(responce);

            var requestData = responce["requested_information"];

            _cachedStudyQueue =  JsonConvert.DeserializeObject<StudyQueue>(requestData.ToString());

            _cachedTimeStudyQueue = DateTime.Now.AddMinutes(CacheInMinutes);
            return _cachedStudyQueue;
        }

        /// <summary>
        /// Retreives information about the current level progression.
        /// </summary>
        /// <param name="noCache">No cached results if set to true</param>
        /// <returns>LevelProgression</returns>
        public LevelProgression LevelProgression(bool noCache = false)
        {
            if (!noCache &&  _cachedLevelProgression != null && _cachedTimeLevelProgression > DateTime.Now)
                return _cachedLevelProgression;

            JObject responce = Request("level-progression");
            UpdateUserInformation(responce);

            var requestData = responce["requested_information"];

            _cachedLevelProgression = JsonConvert.DeserializeObject<LevelProgression>(requestData.ToString());

            _cachedTimeLevelProgression = DateTime.Now.AddMinutes(CacheInMinutes);
            return _cachedLevelProgression;
        }

        /// <summary>
        /// Get the SRS detailed distrobution.
        /// </summary>
        /// <param name="noCache">No cached results if set to true</param>
        /// <returns>SrsDistribution</returns>
        public SrsDistribution SrsDistribution(bool noCache = false)
        {
            if (!noCache && _cachedSrsDistribution != null && _cachedTimeSrsDistribution > DateTime.Now)
                return _cachedSrsDistribution;

            JObject responce = Request("srs-distribution");
            UpdateUserInformation(responce);

            var requestData = responce["requested_information"];

            _cachedSrsDistribution =  JsonConvert.DeserializeObject<SrsDistribution>(requestData.ToString());
            _cachedTimeSrsDistribution = DateTime.Now.AddMinutes(CacheInMinutes);
            return _cachedSrsDistribution;
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


        /// <summary>
        /// Gets all items that is in the users Critical List ( Default 75% or lower) 
        /// This request is not cached.
        /// </summary>
        /// <param name="maxPercentage">The max % failed to retreeive.</param>
        /// <returns>List<BaseCharacter></returns>
        public List<BaseCharacter> CriticalItems(int maxPercentage = 75)
        {
            if (maxPercentage > 100)
                maxPercentage = 100;

            JObject responce = Request("critical-items", maxPercentage.ToString());
            UpdateUserInformation(responce);

            var requestData = responce["requested_information"];

            return JsonConvert.DeserializeObject<List<BaseCharacter>>(requestData.ToString(), new CharacterTypeCreationConverter());
        }

        /// <summary>
        /// Get all unlocked Radicals up to given level, if no level given will get all unlocked.
        /// </summary>
        /// <param name="maxLevel">Max level to get</param>
        /// <returns>List of Radicals</returns>
        public List<Radical> Radicals(int maxLevel = 0)
        {
            if (maxLevel == 0)
            {
                if (_cachedUserInformation == null)
                    throw new Exception("No cached user information, do not know max level so plase enter your own max level");

                maxLevel = _cachedUserInformation.Level;
            }

            return Radicals(string.Join(",", Enumerable.Range(1, maxLevel)));
        }

        /// <summary>
        /// Get all unlocked Radicals from the given range of levels, Each level is comma separated, example 2,3,4. To get a single level you can just enter the level such as 5
        /// </summary>
        /// <param name="maxLevel">Max level to get</param>
        /// <returns>List of Radicals</returns>
        public List<Radical> Radicals(string levels)
        {
            JObject responce = Request("radicals", levels);
            UpdateUserInformation(responce);

            var requestData = responce["requested_information"];

            return JsonConvert.DeserializeObject<List<Radical>>(requestData.ToString());
        }

        /// <summary>
        /// Get all unlocked Kanji up to given level, if no level given will get all unlocked.
        /// </summary>
        /// <param name="maxLevel">Max level to get</param>
        /// <returns>List of Kanjis</returns>
        public List<Kanji> Kanji(int maxLevel = 0)
        {
            if (maxLevel == 0)
            {
                maxLevel = UserInformation().Level;
            }

            return Kanji(string.Join(",", Enumerable.Range(1, maxLevel)));
        }

        /// <summary>
        /// Get all unlocked Kanjis from the given range of levels, Each level is comma separated, example 2,3,4. To get a single level you can just enter the level such as 5
        /// </summary>
        /// <param name="maxLevel">Max level to get</param>
        /// <returns>List of Kanji</returns>
        public List<Kanji> Kanji(string levels)
        {
            JObject responce = Request("kanji", levels);
            UpdateUserInformation(responce);

            var requestData = responce["requested_information"];

            return JsonConvert.DeserializeObject<List<Kanji>>(requestData.ToString());
        }

        /// <summary>
        /// Get all unlocked Vocabulary up to given level, if no level given will get all unlocked.
        /// </summary>
        /// <param name="maxLevel">Max level to get</param>
        /// <returns>List of Vocabulary</returns>
        public List<Vocabulary> Vocabulary(int maxLevel = 0)
        {
            if (maxLevel == 0)
            {
                maxLevel = UserInformation().Level;
            }

            return Vocabulary(string.Join(",", Enumerable.Range(1, maxLevel)));
        }

        /// <summary>
        /// Get all unlocked Vocabulary from the given range of levels, Each level is comma separated, example 2,3,4. To get a single level you can just enter the level such as 5
        /// </summary>
        /// <param name="maxLevel">Max level to get</param>
        /// <returns>List of Vocabulary</returns>
        public List<Vocabulary> Vocabulary(string levels)
        {
            JObject responce = Request("vocabulary", levels);
            UpdateUserInformation(responce);
            
            var requestData = responce["requested_information"];

            return JsonConvert.DeserializeObject<List<Vocabulary>>(requestData.ToString());
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
            WebClient httpClient = new WebClient();
            string responce = httpClient.DownloadString(BuildUrl(resource, optionalArgument));

            return JObject.Parse(responce);
        }

        private void UpdateUserInformation(JObject responce)
        {
            var requestData = responce["user_information"];
            _cachedUserInformation = JsonConvert.DeserializeObject<UserInformation>(requestData.ToString());

            _cachedTimeUserInformation = DateTime.Now.AddMinutes(CacheInMinutes);
        }

    }
}
