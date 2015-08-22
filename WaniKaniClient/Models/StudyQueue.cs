using System;
using Newtonsoft.Json;
using WaniKaniClientLib.Utils;

namespace WaniKaniClientLib.Models
{
    public class StudyQueue
    {
        [JsonProperty("lessons_available")]
        public int LessonsAvailable { get; set; }

        [JsonProperty("reviews_available")]
        public int ReviewsAvailable { get; set; }

        [JsonProperty("next_review_date")]
        public long NextReviewTimeStamp { get; set; }
        public DateTime NextReviewDate
        {
            get
            {
                return Utilities.UnixEpoch.AddSeconds(NextReviewTimeStamp);
            }
        }

        [JsonProperty("reviews_available_next_hour")]
        public int ReviewsAvailableNextHour { get; set; }

        [JsonProperty("reviews_available_next_day")]
        public int ReviewsAvailableNextDay { get; set; }
    }
}
