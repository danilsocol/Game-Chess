using Chess_3._0;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Chess.WPF
{
    public partial class NewGame : Window
    {
        public static ModelBoard board = new ModelBoard();

        public static Button[,] butts = new Button[9, 9];

        public Button[,] cell = new Button[9, 9];
        public NewGame()
        {
            InitializeComponent();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            player = true;
            board.PlacementOfFigureNewGame();

            canvas.Children.Clear();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    butts[i , j ] = new Button();


                    CreateCell field = new CreateCell(i, j);

                    if (i != 0 && j != 0)
                    {
                        field.OutputCellData(canvas, board);
                    }
                    else if (!(i == 0 && j == 0))
                    {
                        field.OutputCellRamk(canvas); // название метода
                    }

                    butts[i , j ] = field.cell;
                }
            }
        }
        private static Button prevButton;
        private static bool ColorGray;
        private static bool IsMoving = false;
        private static bool player;
        private static bool thereIsMove;
        public static void OnFigurePress(object sender, RoutedEventArgs e) // сделать ход
        {
            Button pressedButton = sender as Button;

            if (!IsMoving && ((pressedButton.Foreground == Brushes.Red) == (player)) && pressedButton.Content != null)
            {
                pressedButton.IsEnabled = false;

                if (prevButton != null)
                {
                    if (ColorGray)
                        prevButton.Background = Brushes.Gray;
                    else
                        prevButton.Background = Brushes.White;
                }

                prevButton = pressedButton;

                if (pressedButton.Background == Brushes.Gray)
                {
                    ColorGray = true;
                }
                else
                {
                    ColorGray = false;
                }

                
                pressedButton.Background = Brushes.Green;
                DeactivateAllButtons();
                CloseSteps();
               // pressedButton.IsEnabled = true;

                if (pressedButton.Content != null && ((pressedButton.Foreground == Brushes.Red) == (player)))// подумать до следующих комм
                {
                    IsMoving = true;
                    SetFigure(pressedButton);
                }
            }
            else if(IsMoving)
            {
                thereIsMove = false;
                MakeMove(pressedButton);
                ActivateAllButtons();
                CloseSteps();
             //   IsMoving = false;
            }//
        }

        private static void MakeMove(Button pressedButton)
        {
            pressedButton.Content = prevButton.Content;
            pressedButton.Foreground = prevButton.Foreground;
            prevButton.Content = null;
            prevButton.Foreground = Brushes.Black;

            if (ColorGray)
                prevButton.Background = Brushes.Gray;
            else
                prevButton.Background = Brushes.White;

            prevButton = null;
            IsMoving = false;

            SwitchPlayer();
        }
        private static void SwitchPlayer()
        {
            if (player == true)
                player = false;
            else 
                player = true;
        }

        private static int i;
        private static int j;
        private static int dir;
        private static void SetFigure(Button pressedButton)
        {
            i = int.Parse(Convert.ToString(pressedButton.Name[1]));
            j = int.Parse(Convert.ToString(pressedButton.Name[3]));

            
            if (player == true)
                dir = -1;
            else
                dir = 1;

            switch (pressedButton.Content)
            {
                case "P":
                    ShowMovePawn(j, i);
                    break;

                case "R":
                    ShowVerticalHorizontal(j, i);
                    break;

                case "B":
                    ShowDiagonal(j, i);
                    break;

                case "H":
                    ShowHorseSteps(j, i);
                    break;

                case "Q":
                    ShowVerticalHorizontal(j, i);
                    ShowDiagonal(j, i);
                    break;

                case "K":
                    ShowVerticalHorizontal(j, i, true);
                    ShowDiagonal(j, i, true);
                    break;


            }
            if (!thereIsMove)
            {
                ActivateAllButtons();
                CloseSteps();
                IsMoving = false;
            }
        }
        public static bool InsideBorder(int j, int i)
        {
            if (i >= 9 || j >= 9 || i < 1 || j < 1)
                return false;
            return true;
        }
        public static void CloseSteps()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    if ((i + j) % 2 == 1)
                        butts[i, j].Background = Brushes.Gray;
                    else
                        butts[i, j].Background = Brushes.White;
                }
            }
        }
        public static void DeactivateAllButtons()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    butts[i, j].IsEnabled = false;
                }
            }
        }

        public static void ActivateAllButtons()
        {
            for (int i = 1; i < 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    butts[i, j].IsEnabled = true;
                }
            }
        }
        public static void ShowMovePawn(int j, int i)
        {
            if (InsideBorder(j + 1 * dir, i))
            {
                if (butts[j + 1 * dir, i].Content == null)
                {
                    butts[j + 1 * dir, i].Background = Brushes.Yellow;
                    butts[j + 1 * dir, i].IsEnabled = true;
                    thereIsMove = true;
                }
            }

            if (InsideBorder(j + 1 * dir, i + 1))
            {
                if (butts[j + 1 * dir, i + 1].Content != null && ((butts[j + 1 * dir, i+1].Foreground == Brushes.Red) != player))
                {
                    butts[j + 1 * dir, i + 1].Background = Brushes.Yellow;
                    butts[j + 1 * dir, i + 1].IsEnabled = true;
                    thereIsMove = true;
                }
            }

            if (InsideBorder(j + 1 * dir, i - 1))
            {
                if (butts[j + 1 * dir, i - 1].Content != null && ((butts[j + 1 * dir, i-1].Foreground == Brushes.Red) != player))
                {
                    butts[j + 1 * dir, i - 1].Background = Brushes.Yellow;
                    butts[j + 1 * dir, i - 1].IsEnabled = true;
                    thereIsMove = true;
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
            if (butts[j, i].Content == null)
            {
                butts[j, i].Background = Brushes.Yellow;
                butts[j, i].IsEnabled = true;
                thereIsMove = true;
            }
            else
            {
                if ((butts[j, i].Foreground == Brushes.Red) != player)
                {
                    butts[j, i].Background = Brushes.Yellow;
                   butts[j, i].IsEnabled = true;
                    thereIsMove = true;
                }
                return false;
            }
            return true;
        }
    }
}
