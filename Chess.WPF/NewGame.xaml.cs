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
            board.PlacementOfFigureNewGame();

            canvas.Children.Clear();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    CreateCell field = new CreateCell(i, j);

                    if (i != 0 && j != 0)
                    {
                        field.OutputCellData(canvas, board, i, j);
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
        public static void OnFigurePress(object sender, RoutedEventArgs e)
        {
            Button pressedButton = sender as Button;

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

        }
    }
}
