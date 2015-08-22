using System;
using Newtonsoft.Json;
using WaniKaniClientLib.Utils;

namespace WaniKaniClientLib.Models
{
    public class Stats
    {
        public string Srs { get; set; }

        // The precise stage of SRS the learning item is currently at.
        // Stages 1 to 4 fall within "Apprentice"; stages 5 & 6 are "Guru";
        // Stages 7, 8 and 9 are "Master", "Enlightened" and "Burned"
        // respectively
        [JsonProperty("srs_numeric")]
        public int SrsLevel { get; set; }

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

                return Utilities.UnixEpoch.AddSeconds(UnlockedTimeStamp);
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

                return Utilities.UnixEpoch.AddSeconds(AvailableTimeStamp);
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

                return Utilities.UnixEpoch.AddSeconds(BurnedTimeStamp);
            }
        }

        [JsonProperty("meaning_note")]
        public string MeaningNote { get; set; }

        [JsonProperty("reading_note")]
        public string ReadingNote { get; set; }

        [JsonProperty("user_synonyms")]
        public string UserSynonyms { get; set; }
      
    }
}
