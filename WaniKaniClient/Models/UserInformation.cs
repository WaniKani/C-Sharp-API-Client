using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WaniKaniClient.Models
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

        public DateTime CreatioDate
        {
            get
            {
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return date.AddSeconds(CreationTimeStamp);
            }
        }

    }
}
