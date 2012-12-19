using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WaniKaniClient.Models
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
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return date.AddSeconds(NextReviewTimeStamp);
            }
        }

        [JsonProperty("reviews_available_next_hour")]
        public int ReviewsAvailableNextHour { get; set; }

        [JsonProperty("reviews_available_next_day")]
        public int ReviewsAvailableNextDay { get; set; }
    }
}
