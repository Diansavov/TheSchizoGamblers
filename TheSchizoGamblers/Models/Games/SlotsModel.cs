using Newtonsoft.Json.Bson;

namespace TheSchizoGamblers.Models.Games
{
    public class SlotsModel
    {
        private string[] SlotFigures = ["Cherries", "Plum", "Melon", "Bar", "Diamond", "HorseShoe", "Seven"];
        private int[,] WinPrices = new int[,]
            {
                {3, 3, 3, 8, 10, 15, 50},
                {7, 7, 7, 15, 50, 120, 500},
                {15, 15, 15, 100, 250, 1000, 5000}
            };
        public string[,] SlotsArray { get; set; }
        public decimal Money { get; set; }
        public int Lines { get; set; }

        public SlotsModel()
        {
            Lines = 3;
            SlotsArray = new string[3, 5];
            for (int i = 0; i < SlotsArray.GetLength(0); i++)
            {
                for (int j = 0; j < SlotsArray.GetLength(1); j++)
                {
                    SlotsArray[i, j] = "Diamond";
                }
            }
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
        public decimal CheckWin()
        {
            int tempMoney = 0;
            if (Lines >= 3)
            {
                bool slotsEqual = false;
                for (int i = 0; i < SlotsArray.GetLength(0); i++)
                {
                    for (int j = 0; j < SlotsArray.GetLength(1); j++)
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[i, j]);
                        if (!slotsEqual)
                        {
                            break;
                        }
                        if (j >= 2)
                        {
                            int type = Array.IndexOf(SlotFigures, SlotsArray[i, 0]);
                            tempMoney += GetWinValue(WinPrices, j, type);
                        }
                    }
                }
            }
            return tempMoney;
        }
        static int GetWinValue(int[,] WinPrices, int streakOfLines, int type)
        {
            return WinPrices[streakOfLines - 2, type];
        }

    }

}
