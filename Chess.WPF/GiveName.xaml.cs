using Chess_3._0;
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

namespace Chess.WPF
{
    public partial class GiveName : Window
    {
        public GiveName()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            tbErrorLenght.Visibility = Visibility.Hidden;
            tbErrorDoubleName.Visibility = Visibility.Hidden;

            if (CheckName())
            {
                ModelBoard.PlayerOne = new Player(tbOnePlayer.Text);
                ModelBoard.PlayerTwo = new Player(tbTwoPlayer.Text);

                NewGame newGame = new NewGame();
                newGame.Show();
                Close();
            }
        }
        private bool CheckName()
        {
            if (tbOnePlayer.Text.Length <= 2 && tbTwoPlayer.Text.Length <= 2)
            {
                tbErrorLenght.Visibility = Visibility.Visible;
                return false;
            }
            if (tbOnePlayer.Text == tbTwoPlayer.Text)
            {
                tbErrorDoubleName.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

    }
}
