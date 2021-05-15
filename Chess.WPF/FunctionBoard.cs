using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Media;

namespace Chess.WPF
{
    class FunctionBoard
    {
        public static void CloseSteps()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if ((i + j) % 2 == 1)
                        NewGame.butts[i, j].Background = Brushes.Gray;
                    else
                        NewGame.butts[i, j].Background = Brushes.White;
                }
            }
        }


        public static void DeactivateAllButtons()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    NewGame.butts[i, j].IsEnabled = false;
                }
            }
        }

        public static void ActivateAllButtons()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    NewGame.butts[i, j].IsEnabled = true;
                }
            }
        }

        public static void SaveField(string dataPlayers)
        {
            string[] cellInFile = new string[8];

            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if (NewGame.butts[i, j].Content != null)
                        cellInFile[i - 1] += Convert.ToString(NewGame.butts[i, j].Content);
                    else
                        cellInFile[i - 1] += "VV ";

                    if (NewGame.butts[i, j].Foreground == Brushes.Red)
                        cellInFile[i - 1] += "R ";
                    else if (NewGame.butts[i, j].Foreground == Brushes.Blue)
                        cellInFile[i - 1] += "B ";

                }
                File.WriteAllLines("Save\\SaveBoard.txt", cellInFile);
            }
            File.WriteAllText("Save\\SavePlayer.txt", dataPlayers);
        }
    }
}
