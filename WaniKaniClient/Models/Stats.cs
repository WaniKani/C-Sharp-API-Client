using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WaniKaniClientLib.Models
{
    public class Stats
    {
        public string Srs { get; set; }
        public bool Burned { get; set; }

        [JsonProperty("meaning_correct")]
        public int? MeaningCorrect { get; set; }

        [JsonProperty("meaning_incorrect")]
        public int? MeaningIncorrect { get; set; }

        [JsonProperty("meaning_max_streak")]
        public int? MeaningMaxStreak { get; set; }

        [JsonProperty("meaning_current_streak")]
        public int? MeaningCurrentStreak { get; set; }

        [JsonProperty("reading_correct")]
        public int? ReadingCorrect { get; set; }

        [JsonProperty("reading_incorrect")]
        public int? ReadingIncorrect { get; set; }

        [JsonProperty("reading_max_streak")]
        public int? ReadingMaxStreak { get; set; }

        [JsonProperty("reading_current_streak")]
        public int? ReadingCurrentStreak { get; set; }
        
        [JsonProperty("unlocked_date")]
        public long UnlockedTimeStamp { get; set; }
        public DateTime? UnlockedDate
        {
            get
            {
                if (UnlockedTimeStamp == 0)
                    return null;

                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return date.AddSeconds(UnlockedTimeStamp);
            }
        }

        [JsonProperty("available_date")]
        public long AvailableTimeStamp { get; set; }
        public DateTime? AvailableDate
        {
            get
            {
                if (AvailableTimeStamp == 0)
                    return null;

                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return date.AddSeconds(AvailableTimeStamp);
            }
        }

        [JsonProperty("burned_date")]
        public long BurnedTimeStamp { get; set; }
        public DateTime? BurnedDate
        {
            get
            {
                if (BurnedTimeStamp == 0)
                    return null;

                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return date.AddSeconds(BurnedTimeStamp);
            }
        }
      
    }
}
