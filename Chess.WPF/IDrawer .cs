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
    class IDrawer
    {
        private int x, y;
        private bool color;
        public Button cell = new Button();

        public IDrawer(int xXx, int yYy)
        {
            x = xXx;
            y = yYy;

            if ((x + y) % 2 == 1)
                color = true;
            else
                color = false;
        }

        public void OutputCellBoard(Canvas canvas, ModelBoard board)
        {
            var cellSize = (canvas.ActualHeight + canvas.ActualWidth) / 20;

            cell.Width = cellSize;
            cell.Height = cellSize;
            cell.Name = $"x{y}y{x}";

            if (color)
                cell.Background = Brushes.Gray;
            else
                cell.Background = Brushes.White;

            if (board.cell[y - 1, x - 1].Role != Roles.V)
            {
                cell.Content = Convert.ToString(board.cell[y - 1, x - 1].Role);

                if (board.cell[y - 1, x - 1].Color == Chess_3._0.Colors.White)
                {
                    cell.Foreground = Brushes.Red;
                    cell.Foreground = Brushes.Red;
                }
                else
                {
                    cell.Foreground = Brushes.Blue;
                    cell.Foreground = Brushes.Blue;
                }
            }

            cell.FontSize = cellSize / 4;

            canvas.Children.Add(cell);

            Canvas.SetTop(cell, x * cellSize);
            Canvas.SetLeft(cell, y * cellSize);
        }

        private static char ch = 'A';
        public void OutputCellRamk(Canvas canvas)
        {
            var cellSize = (canvas.ActualHeight + canvas.ActualWidth) / 20;

            var borden = new Border();
            var text = new TextBlock();
            text.Text = Convert.ToString(ch);

            if (ch == 'H')
                ch = (char)(ch - 24);

            ch = (char)(ch + 1);

            text.Height = cellSize / 4;
            text.Width = cellSize / 4;
            text.FontSize = cellSize / 4;

            borden.Width = cellSize;
            borden.Height = cellSize;

            borden.Child = text;
            canvas.Children.Add(borden);

            Canvas.SetTop(borden, x * cellSize);
            Canvas.SetLeft(borden, y * cellSize);

            if (ch == '9')
                ch = 'A';
        }
    }
}
