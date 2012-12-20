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

        public Stats Stats { get; set; }
    }
}
