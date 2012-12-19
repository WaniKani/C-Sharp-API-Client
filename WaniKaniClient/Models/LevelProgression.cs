using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace WaniKaniClient.Models
{
    public class LevelProgression
    {
        [JsonProperty("radicals_progress")]
        public int RadicalsProgress { get; set; }
        
        [JsonProperty("radicals_total")]
        public int RadicalsTotal { get; set; }
        
        [JsonProperty("kanji_progress")]
        public int KanjiProgress { get; set; }
        
        [JsonProperty("kanji_total")]
        public int KanjiTotal { get; set; }
    }
}
