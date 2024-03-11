using Newtonsoft.Json.Bson;

namespace TheSchizoGamblers.Models.Games
{
    public class SlotsModel
    {
        private string[] SlotFigures = ["Cherries", "Plum", "Melon", "Bar", "Diamond", "HorseShoe", "Seven"];
        private int[,] WinPrices = new int[,]
            {
                {3, 3, 3, 3, 10, 15, 20},
                {5, 5, 5, 5, 20, 20, 30},
                {15, 15, 15, 15, 30, 35, 55}
            };
        public string[,] SlotsArray { get; set; }
        public double Money { get; set; }
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
        public void CheckWin()
        {
            int tempMoney = 0;
            if (Lines >= 3)
            {
                bool slotsEqual = false;
                for (int i = 0; i < SlotsArray.GetLength(0); i++)
                {
                    for (int j = 0; j < SlotsArray.GetLength(1); j++)
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[1, j]);
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
            Money += tempMoney;
        }
        static int GetWinValue(int[,] WinPrices, int streakOfLines, int type)
        {
            return WinPrices[streakOfLines - 2, type];
        }

    }

}
