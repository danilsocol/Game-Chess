using Chess_3._0;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace Chess.WPF
{
    public class AvailableMoves
    {
        public static bool InsideBorder(int j, int i)
        {
            if (i >= 9 || j >= 9 || i < 1 || j < 1)
                return false;
            return true;
        }

        public static void ShowMovePawn(int j, int i, int dir)
        {
            if (InsideBorder(j + 1 * dir, i))
            {
                if (NewGame.butts[j + 1 * dir, i].Content == null)
                {
                    NewGame.butts[j + 1 * dir, i].Background = Brushes.Yellow;
                    NewGame.butts[j + 1 * dir, i].IsEnabled = true;
                    NewGame.thereIsMove = true;
                }
            }

            if (InsideBorder(j + 1 * dir, i + 1))
            {
                if (NewGame.butts[j + 1 * dir, i + 1].Content != null && ((NewGame.butts[j + 1 * dir, i + 1].Foreground == Brushes.Red) != NewGame.MovePlayerOne))
                {
                    NewGame.butts[j + 1 * dir, i + 1].Background = Brushes.Yellow;
                    NewGame.butts[j + 1 * dir, i + 1].IsEnabled = true;
                    NewGame.thereIsMove = true;
                }
            }

            if (InsideBorder(j + 1 * dir, i - 1))
            {
                if (NewGame.butts[j + 1 * dir, i - 1].Content != null && ((NewGame.butts[j + 1 * dir, i - 1].Foreground == Brushes.Red) != NewGame.MovePlayerOne))
                {
                    NewGame.butts[j + 1 * dir, i - 1].Background = Brushes.Yellow;
                    NewGame.butts[j + 1 * dir, i - 1].IsEnabled = true;
                    NewGame.thereIsMove = true;
                }
            }
        }

        public static void ShowHorseSteps(int j, int i)
        {
            if (InsideBorder(j - 2, i + 1))
            {
                DeterminePath(j - 2, i + 1);
            }
            if (InsideBorder(j - 2, i - 1))
            {
                DeterminePath(j - 2, i - 1);
            }
            if (InsideBorder(j + 2, i + 1))
            {
                DeterminePath(j + 2, i + 1);
            }
            if (InsideBorder(j + 2, i - 1))
            {
                DeterminePath(j + 2, i - 1);
            }
            if (InsideBorder(j - 1, i + 2))
            {
                DeterminePath(j - 1, i + 2);
            }
            if (InsideBorder(j + 1, i + 2))
            {
                DeterminePath(j + 1, i + 2);
            }
            if (InsideBorder(j - 1, i - 2))
            {
                DeterminePath(j - 1, i - 2);
            }
            if (InsideBorder(j + 1, i - 2))
            {
                DeterminePath(j + 1, i - 2);
            }
        }

        public static void ShowDiagonal(int J, int I, bool isOneStep = false)
        {
            int j = I + 1;
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
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
                    if (!DeterminePath(i, j))
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
                    if (!DeterminePath(i, j))
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
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 8)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }
        public static void ShowVerticalHorizontal(int J, int I, bool isOneStep = false)
        {
            for (int i = J + 1; i < 9; i++)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePath(i, I))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int i = J - 1; i >= 1; i--)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePath(i, I))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I + 1; j < 9; j++)
            {
                if (InsideBorder(J, j))
                {
                    if (!DeterminePath(J, j))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I - 1; j >= 1; j--)
            {
                if (InsideBorder(J, j))
                {
                    if (!DeterminePath(J, j))
                        break;
                }
                if (isOneStep)
                    break;
            }
        }
        public static bool DeterminePath(int j, int i)
        {
            if (NewGame.butts[j, i].Content == null)
            {
                NewGame.butts[j, i].Background = Brushes.Yellow;
                NewGame.butts[j, i].IsEnabled = true;
                NewGame.thereIsMove = true;
            }
            else
            {
                if ((NewGame.butts[j, i].Foreground == Brushes.Red) != NewGame.MovePlayerOne)
                {
                    NewGame.butts[j, i].Background = Brushes.Yellow;
                    NewGame.butts[j, i].IsEnabled = true;
                    NewGame.thereIsMove = true;
                }
                return false;
            }
            return true;
        }
    }
}
