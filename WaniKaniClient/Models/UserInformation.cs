using System;
using Newtonsoft.Json;
using WaniKaniClientLib.Utils;

namespace WaniKaniClientLib.Models
{
    public class UserInformation
    {
        public string UserName { get; set; }
        public string Gravatar { get; set; }
        public int Level { get; set; }
        public string Title { get; set; }
        public string About { get; set; }
        public string Website { get; set; }
        public string Twitter { get; set; }

        [JsonProperty("topics_count")]
        public int TopicsCount { get; set; }

        [JsonProperty("posts_count")]
        public int PostsCount { get; set; }

        [JsonProperty("creation_date")]
        public long CreationTimeStamp { get; set; }
        public DateTime CreationDate
        {
            get
            {
                return Utilities.UnixEpoch.AddSeconds(CreationTimeStamp);
            }
        }

        // We have to use a nullable long here as the vacation date is passed as "null" in the API
        // if the user is not on vacation, rather than being omitted as in learning items
        [JsonProperty("vacation_date")]
        public long? VacationTimeStamp { get; set; }
        public DateTime? VacationDate
        {
            get
            {
                if (VacationTimeStamp.HasValue)
                {
                    return Utilities.UnixEpoch.AddSeconds(VacationTimeStamp.Value);
                }
                return null;
            }
        }
    }
}
