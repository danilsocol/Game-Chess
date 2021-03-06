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

        private static ModelBoard board { get; } = new ModelBoard();
        public static Button[,] buttsBoard { get; } = new Button[9, 9];
        public static Button prevButton { get; set; }
        public static bool colorCellGray { get; set; }
        public static bool isMoving { get; set; } = false;
        public static bool thereIsMove { get; set; } = false;

        public NewGame()
        {
            InitializeComponent();

            this.Closing += NewGame_Closing;
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
                    buttsBoard[i , j] = new Button();


                    IDrawer field = new IDrawer(i, j);

                    if (i != 0 && j != 0)
                    {
                        field.OutputCellBoard(canvas, board);
                        
                    }
                    else if (!(i == 0 && j == 0))
                    {
                        field.OutputCellRamk(canvas);
                    }

                    buttsBoard[i , j ] = field.cell;
                    buttsBoard[i, j].Click += new RoutedEventHandler(OnFigurePress);
                }
            }
        }

        private void OnFigurePress(object sender, RoutedEventArgs e) 
        {
            Button pressedButton = sender as Button;
            tbPlayer1Score.Text = Convert.ToString(ModelBoard.PlayerOne.Score);
            tbPlayer2Score.Text = Convert.ToString(ModelBoard.PlayerTwo.Score);

            if (!isMoving && ((pressedButton.Foreground == Brushes.Red) == (board.MovePlayerOne)) && pressedButton.Content != null)
            {
                pressedButton.IsEnabled = false;

                if (prevButton != null)
                {
                    if (colorCellGray)
                        prevButton.Background = Brushes.Gray;
                    else
                        prevButton.Background = Brushes.White;
                }

                prevButton = pressedButton;

                if (pressedButton.Background == Brushes.Gray)
                {
                    colorCellGray = true;
                }
                else
                {
                    colorCellGray = false;
                }

                pressedButton.Background = Brushes.Green;
                FunctionBoard.DeactivateAllButtons();
                FunctionBoard.CloseSteps();

                if (pressedButton.Content != null && ((pressedButton.Foreground == Brushes.Red) == (board.MovePlayerOne)))
                {
                    isMoving = true;
                    GameActions.PaintCorrectMove(pressedButton, board);
                }
            }
            else if (isMoving)
            {
                isMoving = false;
                GameActions.MakeMove(pressedButton, board);
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

            if (board.MovePlayerOne == true)
            {
                tbPlayer2Name.Foreground = Brushes.Black;
                tbPlayer1Name.Foreground = Brushes.Red;

                board.MovePlayerOne = false;
            }
            else
            {
                tbPlayer2Name.Foreground = Brushes.Red;
                tbPlayer1Name.Foreground = Brushes.Black;

                board.MovePlayerOne = true;
            }
        }

        private void NewGame_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var menu = new MainWindow();
            menu.Show();
        }
    }
}
