using Newtonsoft.Json.Bson;

namespace TheSchizoGamblers.Models.Games
{
    public class SlotsModel
    {
        private string[] SlotFigures = ["Cherries", "Plum", "Melon", "Bar", "Diamond", "HorseShoe", "Seven"];
        private bool SlotsEqual = false;
        public string[,] SlotsArray { get; set; }
        public double Money { get; set; }
        public SlotsModel()
        {
            SlotsArray = new string[3, 5];

        }

        public void Randomize()
        {
            Random random = new Random();

            for (int i = 0; i < SlotsArray.GetLength(0); i++)
            {
                for (int j = 0; j < SlotsArray.GetLength(1); j++)
                {
                    SlotsArray[i, j] = SlotFigures[random.Next(0, 7)];
                }
            }

        }
        public bool CheckWin()
        {
            for (int i = 0; i < SlotsArray.GetLength(1); i++)
            {
                SlotsEqual = SlotsArray[1, 0].Equals(SlotsArray[1, i]);
                if (!SlotsEqual)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
