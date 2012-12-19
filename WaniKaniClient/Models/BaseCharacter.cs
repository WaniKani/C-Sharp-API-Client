using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WaniKaniClientLib.Models
{
    public class BaseCharacter
    {
        public CharacterType Type { get; set; }
        public string Character { get; set; }
        public string Meaning { get; set; }
        public int Level { get; set; }

        [JsonProperty("unlocked_date")]
        public long UnlockTimeStamp { get; set; }
        public DateTime UnlockedDate
        {
            get
            {
                var date = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                return date.AddSeconds(UnlockTimeStamp);
            }
        }

        public string Percentage { get; set; }

      //  "stats": {
      //  "srs": "enlighten",
      //  "unlocked_date": 1337747704,
      //  "available_date": 1359290034,
      //  "burned": false,
      //  "burned_date": 0,
      //  "meaning_correct": 11,
      //  "meaning_incorrect": 0,
      //  "meaning_max_streak": 11,
      //  "meaning_current_streak": 11,
      //  "reading_correct": 11,
      //  "reading_incorrect": 4,
      //  "reading_max_streak": 9,
      //  "reading_current_streak": 9
      //}
    }
}
