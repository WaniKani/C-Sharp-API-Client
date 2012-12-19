using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaniKaniClientLib.Models
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
