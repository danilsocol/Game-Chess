using Chess_3._0;
using System;
using System.IO;
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

            if (MainWindow.IsNewGame)
            {
                board.PlacementOfFigureNewGame();
            }
            else
            {
                string[] namesAndScore = (File.ReadAllText("Save\\SavePlayer.txt")).Split(' ');

                board.PlacementOfFigureContinue();
            }


            tbPlayer1Score.Text = Convert.ToString(ModelBoard.PlayerOne.Score);
            tbPlayer2Score.Text = Convert.ToString(ModelBoard.PlayerTwo.Score);
            tbPlayer1Name.Text = ModelBoard.PlayerOne.Name;
            tbPlayer2Name.Text = ModelBoard.PlayerTwo.Name;

            tbPlayer2Name.Foreground = Brushes.Red;

            canvas.Children.Clear();

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    butts[i , j] = new Button();


                    CreateCell field = new CreateCell(i, j);

                    if (i != 0 && j != 0)
                    {
                        field.OutputCellData(canvas, board);
                        
                    }
                    else if (!(i == 0 && j == 0))
                    {
                        field.OutputCellRamk(canvas);
                    }

                    butts[i , j ] = field.cell;
                    butts[i, j].Click += new RoutedEventHandler(OnFigurePress);
                }
            }
        }

        public static Button prevButton;
        public static bool ColorGray;
        public static bool IsMoving = false;
        public static bool player = true;
        public static bool thereIsMove;

        public void OnFigurePress(object sender, RoutedEventArgs e) // сделать ход
        {
            Button pressedButton = sender as Button;
            tbPlayer1Score.Text = Convert.ToString(ModelBoard.PlayerOne.Score);
            tbPlayer2Score.Text = Convert.ToString(ModelBoard.PlayerTwo.Score);

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
                FunctionBoard.DeactivateAllButtons();
                FunctionBoard.CloseSteps();

                if (pressedButton.Content != null && ((pressedButton.Foreground == Brushes.Red) == (player)))// подумать до следующих комм
                {
                    IsMoving = true;
                    GameActions.SetFigure(pressedButton);
                }
            }
            else if (IsMoving)
            {
                thereIsMove = false;
                GameActions.MakeMove(pressedButton);
                FunctionBoard.ActivateAllButtons();
                FunctionBoard.CloseSteps();
                FunctionBoard.SaveField($"{ tbPlayer1Name.Text} { tbPlayer1Score.Text} { tbPlayer2Name.Text} { tbPlayer2Score.Text}");
                SwitchPlayer();
            }
        }
        private void SwitchPlayer()
        {
            tbPlayer1Score.Text = Convert.ToString(ModelBoard.PlayerOne.Score);
            tbPlayer2Score.Text = Convert.ToString(ModelBoard.PlayerTwo.Score);

            if (player == true)
            {
                tbPlayer2Name.Foreground = Brushes.Black;
                tbPlayer1Name.Foreground = Brushes.Red;

                player = false;
            }
            else
            {
                tbPlayer2Name.Foreground = Brushes.Red;
                tbPlayer1Name.Foreground = Brushes.Black;

                player = true;
            }
        }
    }
}
