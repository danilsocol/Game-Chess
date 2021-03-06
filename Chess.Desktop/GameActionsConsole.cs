using Chess_3._0;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Desktop
{
    class GameActionsConsole
    {
        private static ModelBoard board { get; } = new ModelBoard();
        private static int[] selectCell { get; } = { 0, 0 };
        private static int[] pastSelectCell { get; } = { 0, 0 };
        private static string[] movementOfTheFigures { get; } = new string[2];

        public static void CreateUser(Player player)
        {
            do
            {
                player = new Player(WorkConsole.ReadName());
                Console.Clear();

            } while (player.Name.Length == 0);
        }
        public static void Action()
        {

            board.PlacementOfFigureNewGame();
            CreateUser(ModelBoard.PlayerOne);
            CreateUser(ModelBoard.PlayerTwo);

            while (true)
            {
                WorkConsole.WriteField(board.cell);

                SelectCell();

                MakeMove(movementOfTheFigures, board.cell);
                
            }
        }
        private static void MakeMove(string[] move, Cell[,] cell)
        {
            string start = move[0];

            if (!RecognitionFigureInCell(cell, start))
                WorkConsole.Error();

            string end = move[1];

            bool isCorrect = CheckCorrectOfTheMove(board, start, end);

            int StartHorizontalCood = start[1] - 48;
            int StartVerticalCoord = start[0] - 48;

            int EndHorizontalCood = end[1] - 48;
            int EndVerticalCoord = end[0] - 48;

            
            if (isCorrect)
            {
                board.cell[EndVerticalCoord, EndHorizontalCood].Color = board.cell[StartVerticalCoord, StartHorizontalCood].Color;
                board.cell[EndVerticalCoord, EndHorizontalCood].Role = board.cell[StartVerticalCoord, StartHorizontalCood].Role;
                board.cell[StartVerticalCoord, StartHorizontalCood].Role = Roles.V;
                board.cell[StartVerticalCoord, StartHorizontalCood].Color = Colors.V;
            }   
            else
                WorkConsole.Error();
        }

        public static void SelectCell()
        {
            bool IsTheFigureSelected = true;

            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.DownArrow && selectCell[1] < 7) selectCell[1]++;
                if (key == ConsoleKey.UpArrow && selectCell[1] > 0) selectCell[1]--;
                if (key == ConsoleKey.RightArrow && selectCell[0] < 7) selectCell[0]++;
                if (key == ConsoleKey.LeftArrow && selectCell[0] > 0) selectCell[0]--;

                WorkConsole.WriteChoiceCell(selectCell, pastSelectCell, board.cell);


                if (key == ConsoleKey.Enter && !IsTheFigureSelected)
                {
                    movementOfTheFigures[1] = $"{selectCell[0]}{selectCell[1]}";
                    break;
                }

                if (key == ConsoleKey.Enter && IsTheFigureSelected && RecognitionFigureInCell(board.cell, $"{selectCell[0]}{selectCell[1]}"))
                {
                    movementOfTheFigures[0] = $"{selectCell[0]}{selectCell[1]}";
                    IsTheFigureSelected = false;
                }
            }
        }

        private static bool CheckCorrectOfTheMove(ModelBoard board, string start, string end)
        {
            List<string> listCorrectMove = new List<string>();

            CorrectMoves.SetFigure(start[0] - 47, start[1] - 47, board, listCorrectMove, Convert.ToString(board.cell[start[0] - 48, start[1] - 48].Role));
            
            for (int i =0; i < listCorrectMove.Count; i++)
            {
                if (end == listCorrectMove[i])
                {
                    board.MovePlayerOne = !board.MovePlayerOne;
                    return true;
                }
                    
            }
            return false;
        }
        private static bool RecognitionFigureInCell(Cell[,] cell, string start)
        {
            if ((cell[start[0] - 48, start[1] - 48]).Role == Roles.V || (cell[start[0] - 48, start[1] - 48].Color == Colors.White) != board.MovePlayerOne)
                return false;
            else
                return true;
        }
    }
}
