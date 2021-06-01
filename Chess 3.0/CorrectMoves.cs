using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_3._0
{
    public class CorrectMoves
    {
        public static bool InsideBorder(int j, int i)
        {
            if (i >= 9 || j >= 9 || i < 1 || j < 1)
                return false;
            return true;
        }

        public static void ShowMovePawn(int j, int i, int dir, ModelBoard board, List<string> CorrectMove)
        {

            if (InsideBorder(j , i + 1 * dir))
            {
                if (board.cell[j-1, i + 1 * dir-1].Role == Roles.V)
                {
                    CorrectMove.Add($"{j - 1}{ i + 1 * dir - 1}");

                    //NewGame.butts[j + 1 * dir, i].Background = Brushes.Yellow;
                    //NewGame.butts[j + 1 * dir, i].IsEnabled = true;
                    //NewGame.thereIsMove = true;
                }
            }

            if (InsideBorder(j+1, i + 1 * dir))
            {
                if (board.cell[j , i + 1 * dir-1].Role != Roles.V && ((board.cell[j, i + 1 * dir - 1].Color == Colors.Black) != board.MovePlayerOne))
                {
                    CorrectMove.Add($"{j }{ i + 1 * dir - 1}");
                    //NewGame.butts[j + 1 * dir, i + 1].Background = Brushes.Yellow;
                    //NewGame.butts[j + 1 * dir, i + 1].IsEnabled = true;
                    //NewGame.thereIsMove = true;
                }
            }

            if (InsideBorder(j -1, i + 1 * dir))
            {
                if (board.cell[j - 2, i + 1 * dir-1].Role != Roles.V && ((board.cell[j - 2, i + 1 * dir - 1].Color == Colors.Black) != board.MovePlayerOne))
                {
                    CorrectMove.Add($"{j - 2}{i + 1 * dir - 1}");
                    //NewGame.butts[j + 1 * dir, i - 1].Background = Brushes.Yellow;
                    //NewGame.butts[j + 1 * dir, i - 1].IsEnabled = true;
                    //NewGame.thereIsMove = true;
                }
            }
        }

        public static void ShowHorseSteps(int j, int i, ModelBoard board, List<string> CorrectMove)
        {
           // List<string> CorrectMove = new List<string>();
            if (InsideBorder(j - 2, i + 1))
            {
                DeterminePathL(j - 2, i + 1, board, CorrectMove);
            }
            if (InsideBorder(j - 2, i - 1))
            {
                DeterminePathL(j - 2, i - 1, board, CorrectMove);
            }
            if (InsideBorder(j + 2, i + 1))
            {
                DeterminePathL(j + 2, i + 1, board, CorrectMove);
            }
            if (InsideBorder(j + 2, i - 1))
            {
                DeterminePathL(j + 2, i - 1, board, CorrectMove);
            }
            if (InsideBorder(j - 1, i + 2))
            {
                DeterminePathL(j - 1, i + 2, board, CorrectMove);
            }
            if (InsideBorder(j + 1, i + 2))
            {
                DeterminePathL(j + 1, i + 2, board, CorrectMove);
            }
            if (InsideBorder(j - 1, i - 2))
            {
                DeterminePathL(j - 1, i - 2, board, CorrectMove);
            }
            if (InsideBorder(j + 1, i - 2))
            {
                DeterminePathL(j + 1, i - 2, board, CorrectMove);
            }
        }

        public static void ShowDiagonal(int J, int I, ModelBoard board, List<string> CorrectMove, bool isOneStep = false)
        {
            int j = I + 1;
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePathL(i, j, board,CorrectMove))
                        break;
                }
                if (j < 8)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = I - 1;
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePathL(i, j, board, CorrectMove))
                        break;
                }
                if (j > 1)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = I - 1;
            for (int i = J + 1; i < 9; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePathL(i, j, board, CorrectMove))
                        break;
                }
                if (j > 1)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = I + 1;
            for (int i = J + 1; i < 9; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePathL(i, j, board, CorrectMove))
                        break;
                }
                if (j < 8)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }
        public static void ShowVerticalHorizontal(int J, int I,  ModelBoard board, List<string> CorrectMove, bool isOneStep = false)
        {
            
            for (int i = J + 1; i < 9; i++)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePathL(i, I, board, CorrectMove))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePathL(i, I, board, CorrectMove))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I + 1; j < 9; j++)
            {
                if (InsideBorder(J, j))
                {
                    if (!DeterminePathL(J, j, board, CorrectMove))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I - 1; j >= 1; j--)
            {
                if (InsideBorder(J, j))
                {
                    if (!DeterminePathL(J, j, board, CorrectMove))
                        break;
                }
                if (isOneStep)
                    break;
            }

            
            }
        public static bool DeterminePathL(int j, int i, ModelBoard board,List<string> CorrectMove)
        {
            if (board.cell[j - 1, i - 1].Role == Roles.V && ((board.cell[j - 1, i - 1].Color == Colors.Black) != board.MovePlayerOne))
            {
                CorrectMove.Add($"{j - 1}{i - 1}");
                //NewGame.butts[j, i].Background = Brushes.Yellow;
                //NewGame.butts[j, i].IsEnabled = true;
                //NewGame.thereIsMove = true;
            }
            else
            {
                //if ((board.cell[j, i].Color == Colors.Black) != NewGame.MovePlayerOne)
                //{
                //    NewGame.butts[j, i].Background = Brushes.Yellow;
                //    NewGame.butts[j, i].IsEnabled = true;
                //    NewGame.thereIsMove = true;
                //}
                return false;
            }
            return true;
        }
    }
}
