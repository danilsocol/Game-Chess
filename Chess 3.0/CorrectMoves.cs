using System;
using System.Collections.Generic;
using System.Text;
namespace Chess_3._0
{
    public class CorrectMoves
    {
        public static void SetFigure(int i, int j,ModelBoard board,List<string> listCorrectMove, string pressedButton)
        {
            int dir;

            if (board.MovePlayerOne == true)
                dir = -1;
            else
                dir = 1;

            switch (pressedButton)
            {
                case "P":
                    ShowMovePawn(i, j, dir, board, listCorrectMove);
                    break;

                case "R":
                    ShowVerticalHorizontal(i, j, board, listCorrectMove);
                    break;

                case "B":
                    ShowDiagonal(i, j, board, listCorrectMove);
                    break;

                case "H":
                    ShowHorseSteps(i, j, board, listCorrectMove);
                    break;

                case "Q":
                    ShowVerticalHorizontal(i, j, board, listCorrectMove);
                    ShowDiagonal(i, j, board, listCorrectMove);
                    break;

                case "K":
                    ShowVerticalHorizontal(i, j, board, listCorrectMove, true);
                    ShowDiagonal(i, j, board, listCorrectMove, true);
                    break;
            }
        }

        public static bool InsideBorder(int j, int i)
        {
            if (i >= 9 || j >= 9 || i < 1 || j < 1)
                return false;
            return true;
        }

        private static void ShowMovePawn(int j, int i, int dir, ModelBoard board, List<string> CorrectMove)
        {

            if (InsideBorder(j , i + 1 * dir))
            {
                if (board.cell[j-1, i + 1 * dir-1].Role == Roles.V)
                {
                    CorrectMove.Add($"{j - 1}{ i + 1 * dir - 1}");
                }
            }

            if (InsideBorder(j+1, i + 1 * dir))
            {
                if (board.cell[j , i + 1 * dir-1].Role != Roles.V && ((board.cell[j, i + 1 * dir - 1].Color == Colors.White) != board.MovePlayerOne))
                {
                    CorrectMove.Add($"{j }{ i + 1 * dir - 1}");
                }
            }

            if (InsideBorder(j -1, i + 1 * dir))
            {
                if (board.cell[j - 2, i + 1 * dir-1].Role != Roles.V && ((board.cell[j - 2, i + 1 * dir - 1].Color == Colors.White) != board.MovePlayerOne))
                {
                    CorrectMove.Add($"{j - 2}{i + 1 * dir - 1}");
                }
            }
        }

        private static void ShowHorseSteps(int j, int i, ModelBoard board, List<string> CorrectMove)
        {
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

        private static void ShowDiagonal(int J, int I, ModelBoard board, List<string> CorrectMove, bool isOneStep = false)
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
        private static void ShowVerticalHorizontal(int J, int I,  ModelBoard board, List<string> CorrectMove, bool isOneStep = false)
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

        private static bool DeterminePathL(int j, int i, ModelBoard board, List<string> CorrectMove)
        {
            if (board.cell[j - 1, i - 1].Role == Roles.V )
            {
                CorrectMove.Add($"{j - 1}{i - 1}");
            }
            else
            {
                if ((board.cell[j - 1, i - 1].Color == Colors.White) != board.MovePlayerOne)
                {
                    CorrectMove.Add($"{j - 1}{i - 1}");
                }
                return false;
            }
            return true;
        }
    }
}
