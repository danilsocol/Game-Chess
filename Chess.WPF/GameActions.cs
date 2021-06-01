using Chess_3._0;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.WPF
{
    class GameActions
    {
        public static void MakeMove(Button pressedButton, ModelBoard board)
        {
            if (NewGame.MovePlayerOne == true)
            {
                ModelBoard.PlayerTwo.AddPoints((string)pressedButton.Content);
            }
            else
            {
                ModelBoard.PlayerOne.AddPoints((string)pressedButton.Content);
            }

            pressedButton.Content = NewGame.prevButton.Content;
            pressedButton.Foreground = NewGame.prevButton.Foreground;
            NewGame.prevButton.Content = null;
            NewGame.prevButton.Foreground = Brushes.Black;

            if (NewGame.colorCellGray)
                NewGame.prevButton.Background = Brushes.Gray;
            else
                NewGame.prevButton.Background = Brushes.White;

            NewGame.prevButton = null;
            NewGame.isMoving = false;
        }
        public static void SetFigure(Button pressedButton, ModelBoard board)
        {
            List<string> listCorrectMove = new List<string>();

            int i = int.Parse(Convert.ToString(pressedButton.Name[1]));
            int j = int.Parse(Convert.ToString(pressedButton.Name[3]));
            int dir;

            if (NewGame.MovePlayerOne == true)
                dir = -1;
            else
                dir = 1;

            switch (pressedButton.Content)
            {
                case "P":
                    AvailableMoves.ShowMovePawn(j, i, dir);
                    break;

                case "R":
                    AvailableMoves.ShowVerticalHorizontal(j, i);
                    break;

                case "B":
                    AvailableMoves.ShowDiagonal(j, i);
                    break;

                case "H":
                    CorrectMoves.ShowHorseSteps(j - 1, i + 1, board, listCorrectMove);
                 //   AvailableMoves.ShowHorseSteps(j, i);
                    break;

                case "Q":
                    AvailableMoves.ShowVerticalHorizontal(j, i);
                    AvailableMoves.ShowDiagonal(j, i);
                    break;

                case "K":
                    AvailableMoves.ShowVerticalHorizontal(j, i, true);
                    AvailableMoves.ShowDiagonal(j, i, true);
                    break;


            }
            if (!NewGame.thereIsMove)
            {
                FunctionBoard.ActivateAllButtons();
                FunctionBoard.CloseSteps();
                NewGame.isMoving = false;
            }

            for (int k = 0; k < listCorrectMove.Count; k++)
            {
                NewGame.butts[listCorrectMove[k][1]-47,listCorrectMove[k][0]-47].Background = Brushes.Yellow;
                NewGame.butts[listCorrectMove[k][1]-47, listCorrectMove[k][0]-47].IsEnabled = true;
                NewGame.thereIsMove = true;
            }
        }

    }
}
