using Chess_3._0;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chess.WPF
{
    public partial class MainWindow : Window
    {
        public static bool IsNewGame;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            IsNewGame = true;
            GiveName giveName = new GiveName();
            giveName.Show();
            Close();
        }
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            IsNewGame = false;
            NewGame giveName = new NewGame();
            giveName.Show();
            Close();
        }
        private void btnOut_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
