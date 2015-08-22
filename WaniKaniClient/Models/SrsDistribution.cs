namespace WaniKaniClientLib.Models
{
    public class SrsDistribution
    {
        public SrsDistributionItem Apprentice { get; set; }
        public SrsDistributionItem Guru { get; set; }
        public SrsDistributionItem Master { get; set; }
        public SrsDistributionItem Enlighten { get; set; }
        public SrsDistributionItem Burned { get; set; }


        public int Radicals
        {
            get
            {
                return Apprentice.Radicals + Guru.Radicals + Master.Radicals + Enlighten.Radicals + Burned.Radicals;
            }
        }

        public int Kanji
        {
            get
            {
                return Apprentice.Kanji + Guru.Kanji + Master.Kanji + Enlighten.Kanji + Burned.Kanji;
            }
        }

        public int Vocabulary
        {
            get
            {
                return Apprentice.Vocabulary + Guru.Vocabulary + Master.Vocabulary + Enlighten.Vocabulary + Burned.Vocabulary;
            }
        }

        public int Total
        {
            get
            {
                return Apprentice.Total + Guru.Total + Master.Total + Enlighten.Total + Burned.Total;
            }
        }
    }


}
