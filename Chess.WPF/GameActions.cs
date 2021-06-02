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
            if (board.MovePlayerOne == true)
            {
                ModelBoard.PlayerTwo.AddPoints((string)pressedButton.Content);
            }
            else
            {
                ModelBoard.PlayerOne.AddPoints((string)pressedButton.Content);
            }

            board.cell[pressedButton.Name[1]-49, pressedButton.Name[3] - 49].Color = board.cell[NewGame.prevButton.Name[1] - 49, NewGame.prevButton.Name[3] - 49].Color;
            board.cell[pressedButton.Name[1] - 49, pressedButton.Name[3] - 49].Role = board.cell[NewGame.prevButton.Name[1] - 49, NewGame.prevButton.Name[3] - 49].Role;
            board.cell[NewGame.prevButton.Name[1] - 49, NewGame.prevButton.Name[3] - 49].Role = Roles.V;
            board.cell[NewGame.prevButton.Name[1] - 49, NewGame.prevButton.Name[3] - 49].Color = Chess_3._0.Colors.V;
            pressedButton.Content = NewGame.prevButton.Content;
            pressedButton.Foreground = NewGame.prevButton.Foreground;
            NewGame.prevButton.Content = null;
            NewGame.prevButton.Foreground = Brushes.Black;
        //    board.MovePlayerOne = !board.MovePlayerOne;

            if (NewGame.colorCellGray)
                NewGame.prevButton.Background = Brushes.Gray;
            else
                NewGame.prevButton.Background = Brushes.White;

            NewGame.prevButton = null;
            NewGame.isMoving = false;
        }
        public static void PaintCorrectMove(Button pressedButton, ModelBoard board)
        {
            List<string> listCorrectMove = new List<string>();

            int i = int.Parse(Convert.ToString(pressedButton.Name[1]));
            int j = int.Parse(Convert.ToString(pressedButton.Name[3]));

            CorrectMoves.SetFigure(i, j, board, listCorrectMove, Convert.ToString(pressedButton.Content));

            for (int k = 0; k < listCorrectMove.Count; k++)
            {
                NewGame.butts[listCorrectMove[k][1] - 47, listCorrectMove[k][0] - 47].Background = Brushes.Yellow;
                NewGame.butts[listCorrectMove[k][1] - 47, listCorrectMove[k][0] - 47].IsEnabled = true;
                NewGame.thereIsMove = true;
            }
            if (!NewGame.thereIsMove)
            {
                FunctionBoard.ActivateAllButtons();
                FunctionBoard.CloseSteps();
                NewGame.isMoving = false;
            }

            
        }

    }
}
