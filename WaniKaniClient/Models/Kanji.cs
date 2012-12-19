using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WaniKaniClient.Models
{
    public class Kanji : BaseCharacter
    {
        public Kanji()
        {
            Type = CharacterType.Kanji;
        }

        public string Onyomi { get; set; }
        public string kunyomi { get; set; }
        
        [JsonProperty("important_reading")]
        public string ImportantReading { get; set; }
    }
}
