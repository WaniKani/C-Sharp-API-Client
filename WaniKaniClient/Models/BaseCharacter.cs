using Newtonsoft.Json;

namespace WaniKaniClientLib.Models
{
    public class BaseCharacter
    {
        public CharacterType Type { get; set; }
        public string Character { get; set; }
        public string Meaning { get; set; }
        public int Level { get; set; }

        [JsonProperty("user_specific")]
        public Stats Stats { get; set; }
    }
}
