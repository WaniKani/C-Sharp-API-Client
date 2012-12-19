using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaniKaniClient.Models
{
    public class Radical : BaseCharacter
    {
        public Radical()
        {
            Type = CharacterType.Radical;
        }

        public string Image { get; set; }
    }
}
