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
