using Newtonsoft.Json;

namespace WaniKaniClientLib.Models
{
    public class Kanji : BaseCharacter
    {
        public Kanji()
        {
            Type = CharacterType.Kanji;
        }

        public string Onyomi { get; set; }
        public string Kunyomi { get; set; }
        public string Nanori { get; set; }
        
        [JsonProperty("important_reading")]
        public string ImportantReading { get; set; }
    }
}
