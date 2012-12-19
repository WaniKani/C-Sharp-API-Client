using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WaniKaniClient.Models
{
    public class Vocabulary : BaseCharacter
    {
        public Vocabulary()
        {
            Type = CharacterType.Vocabulary;
        }
    }
}
