namespace TheSchizoGamblers.Models.Games
{
    public class SlotsModel
    {
        public bool SlotsEqual { get; set; }
        public int[] NumbersArray { get; set; }
        public double Money { get; set; }
        public SlotsModel()
        {
            SlotsEqual = false;
            NumbersArray = new int[3];
        }
    }
}
