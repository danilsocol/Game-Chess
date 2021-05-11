using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chess_3._0;

namespace Chess.WPF
{
    public partial class NewGame : Window
    {
        public ModelBoard board = new ModelBoard();
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
                    CreateCell field = new CreateCell(i, j);

                    if (i != 0 && j != 0)
                    {
                        field.OutputCellData(canvas, board);
                    }
                    else if (!(i == 0 && j == 0))
                    {
                        field.OutputCellRamk(canvas); // название метода
                    }
                }
            }
        }
        private static Button prevButton;
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
                }
            }
            else 
            {
                MakeMove(pressedButton);
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
    }
}
