using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
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
            Lines = 7;
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
                tempMoney += WinCondition3Lines();
            }
            if (Lines >= 7)
            {
                tempMoney += WinCondition7Lines();
            }
            return tempMoney;
        }
        static int GetWinValue(int[,] WinPrices, int streakOfLines, int type)
        {
            return WinPrices[streakOfLines - 2, type];
        }
        private int WinCondition3Lines()
        {
            int tempMoney = 0;
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
            return tempMoney;
        }
        private int WinCondition7Lines()
        {
            int tempMoney = 0;
            bool slotsEqual = false;

            for (int i = 0; i < SlotsArray.GetLength(0); i += 2)
            {
                for (int j = 1; j < SlotsArray.GetLength(1); j++)
                {
                    if (j == 4)
                    {
                        slotsEqual = SlotsArray[1, 0].Equals(SlotsArray[1, j]);
                    }
                    else
                    {
                        slotsEqual = SlotsArray[1, 0].Equals(SlotsArray[i, j]);
                    }

                    if (!slotsEqual)
                    {
                        break;
                    }
                    if (j >= 2)
                    {
                        int type = Array.IndexOf(SlotFigures, SlotsArray[1, 0]);
                        tempMoney += GetWinValue(WinPrices, j, type);
                    }
                }
            }

            for (int i = 0; i < SlotsArray.GetLength(0); i += 2)
            {
                for (int j = 1; j < SlotsArray.GetLength(1); j++)
                {
                    if (j == 4)
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[i, j]);
                    }
                    else
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[1, j]);
                    }

                    if (!slotsEqual)
                    {
                        break;
                    }
                    if (j >= 2)
                    {
                        int type = Array.IndexOf(SlotFigures, SlotsArray[1, 0]);
                        tempMoney += GetWinValue(WinPrices, j, type);
                    }
                }
            }
            return tempMoney;
        }
        private int WinCondition11Lines()
        {
            int tempMoney = 0;
            bool slotsEqual = false;

            for (int i = 0; i < SlotsArray.GetLength(0); i++)
            {
                for (int j = 1; j < SlotsArray.GetLength(1); j++)
                {
                    if (j % 2 == 0)
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[i, j]);
                    }
                    else
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[i + 1, j]);
                    }

                    if (!slotsEqual)
                    {
                        break;
                    }
                    if (j >= 2)
                    {
                        int type = Array.IndexOf(SlotFigures, SlotsArray[1, 0]);
                        tempMoney += GetWinValue(WinPrices, j, type);
                    }
                }
            }
            for (int i = 1; i < SlotsArray.GetLength(0); i++)
            {
                for (int j = 1; j < SlotsArray.GetLength(1); j++)
                {
                    if (j % 2 == 0)
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[i, j]);
                    }
                    else
                    {
                        slotsEqual = SlotsArray[i, 0].Equals(SlotsArray[i - 1, j]);
                    }

                    if (!slotsEqual)
                    {
                        break;
                    }
                    if (j >= 2)
                    {
                        int type = Array.IndexOf(SlotFigures, SlotsArray[1, 0]);
                        tempMoney += GetWinValue(WinPrices, j, type);
                    }
                }
            }
            return tempMoney;
        }
        private int WinCondition13Lines()
        {
            int tempMoney = 0;
            bool slotsEqual = false;

            for (int i = 0; i < SlotsArray.GetLength(0); i++)
            {
                for (int j = 1; j < SlotsArray.GetLength(1); j++)
                {
                    if (j > 2)
                    {
                        slotsEqual = SlotsArray[0, 0].Equals(SlotsArray[j - (j - 1), j]);

                    }
                    else
                    {
                        slotsEqual = SlotsArray[0, 0].Equals(SlotsArray[j, j]);
                    }

                    if (!slotsEqual)
                    {
                        break;
                    }
                    if (j >= 2)
                    {
                        int type = Array.IndexOf(SlotFigures, SlotsArray[1, 0]);
                        tempMoney += GetWinValue(WinPrices, j, type);
                    }
                }
            }
            return tempMoney;
        }

    }

}
