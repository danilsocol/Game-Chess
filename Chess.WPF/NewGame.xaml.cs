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
        private static System.Windows.Controls.Button prevButton;
        private static bool ColorGray;
        private static bool IsMoving = false;
        private static bool player;
        public static void OnFigurePress(object sender, RoutedEventArgs e) // сделать ход
        {
            Button pressedButton = sender as Button;
            

            if (!IsMoving)
            {
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

                if (pressedButton.Content != null && ((pressedButton.Foreground == Brushes.Red) == (player)))// подумать до следующих комм
                {
                    IsMoving = true;
                    SetFigure(pressedButton);
                }
            }
            else 
            {
                MakeMove(pressedButton);
                CloseSteps();
            }//
        }

        private static void MakeMove(Button pressedButton)
        {
            pressedButton.Content = prevButton.Content;
            pressedButton.Foreground = prevButton.Foreground;
            prevButton.Content = null;

            if (ColorGray)
                prevButton.Background = Brushes.Gray;
            else
                prevButton.Background = Brushes.White;

            prevButton = null;
            IsMoving = false;

            SwitchPlayer(pressedButton);
        }
        private static void SwitchPlayer(Button pressedButton)
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
                    if (InsideBorder(j + 1 * dir, i))
                    {
                       if(butts[j + 1 * dir, i].Content == null)
                        {
                            butts[j + 1 * dir,i].Background = Brushes.Yellow;
                           // butts[i + 1 * dir, j].Enabled = true;
                        }
                    }
                    if (InsideBorder(j + 1 * dir, i + 1))
                    {
                        if (butts[j + 1 * dir, i + 1].Content != null &&(( butts[j + 1 * dir, i + 1].Foreground == Brushes.Red) != player))
                        {
                            butts[j + 1 * dir, i + 1].Background = Brushes.Yellow;
                        //    butts[j + 1 * dir, i + 1].Enabled = true;
                        }
                    }
                    if (InsideBorder(j + 1 * dir, i - 1))
                    {
                        if (butts[j + 1 * dir, i - 1].Content != null && ((butts[j + 1 * dir, i + 1].Foreground == Brushes.Red) != player))
                        {
                            butts[j + 1 * dir, i - 1].Background = Brushes.Yellow;
                         //   butts[j + 1 * dir, i - 1].Enabled = true;
                        }
                    }
                    break;

                case "R":
                    ShowDiagonal(j, i);
                    break;

                case "H":
                    ShowHorseSteps(j, i);
                    break;

                case "B":
                    ShowVerticalHorizontal(j, i);
                    break;

                case "Q":
                    ShowVerticalHorizontal(j, i);
                    ShowDiagonal(j, i);
                    break;

                case "K":
                    ShowHorseSteps(j, i);
                    break;

            }
        }
        public static bool InsideBorder(int i, int j)
        {
            if (i >= 8 || j >= 8 || i < 0 || j < 0)
                return false;
            return true;
        }
        public static void CloseSteps()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((i + j) % 2 == 1)
                        butts[i, j].Background = Brushes.Gray;
                    else
                        butts[i, j].Background = Brushes.White;
                    
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
            for (int i = J - 1; i >= 0; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }

            j = I - 1;
            for (int i = J - 1; i >= 0; i--)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = I - 1;
            for (int i = J + 1; i < 8; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j > 0)
                    j--;
                else break;

                if (isOneStep)
                    break;
            }

            j = I + 1;
            for (int i = J + 1; i < 8; i++)
            {
                if (InsideBorder(i, j))
                {
                    if (!DeterminePath(i, j))
                        break;
                }
                if (j < 7)
                    j++;
                else break;

                if (isOneStep)
                    break;
            }
        }

        public static void ShowVerticalHorizontal(int J, int I, bool isOneStep = false)
        {
            for (int i = J + 1; i < 8; i++)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePath(i, I))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int i = J - 1; i >= 0; i--)
            {
                if (InsideBorder(i, I))
                {
                    if (!DeterminePath(i, I))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I + 1; j < 8; j++)
            {
                if (InsideBorder(J, j))
                {
                    if (!DeterminePath(J, j))
                        break;
                }
                if (isOneStep)
                    break;
            }
            for (int j = I - 1; j >= 0; j--)
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
              //  butts[j, i].Enabled = true;
            }
            else
            {
                if ((butts[j + 1 * dir, i + 1].Foreground == Brushes.Red) != player)
                {
                    butts[j, i].Background = Brushes.Yellow;
               //     butts[j, i].Enabled = true;
                }
                return false;
            }
            return true;
        }
    }
}
