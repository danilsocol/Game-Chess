using Chess_3._0;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Desktop
{
    class GameActionsConsole
    {

        private static ModelBoard board { get; } = new ModelBoard();

        private static int[] selectCell = { 0, 0 };
        private static int[] pastSelectCell = { 0, 0 };
        private static string[] movementOfTheFigures = new string[2];

        public static void CreateUser(Player player)
        {
            do
            {
                player = new Player(WorkConsole.ReadName());
                Console.Clear();

            } while (player.Name.Length == 0);
        }
        public static void GameActions()
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

        public static void MakeMove(string[] move, Cell[,] cell)
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

        public static bool CheckCorrectOfTheMove(ModelBoard board, string start, string end)
        {

            bool isCorrect = false;

            switch (board.cell[start[0] - 48, start[1] - 48].Role)
            {
                case Roles.H:
                    isCorrect = IsKnightCorrect(start, end);
                    break;

                case Roles.P:
                    isCorrect = IsPawnCorrect(start, end);
                    break;

                case Roles.R:
                    isCorrect = IsRookCorrect(start, end);
                    break;

                case Roles.Q:
                    isCorrect = IsQueenCorrect(start, end);
                    break;

                case Roles.K:
                    isCorrect = IsKingCorrect(start, end);
                    break;

                case Roles.B:
                    isCorrect = IsBishopCorrect(start, end);
                    break;
            }
            return isCorrect;
        }

        public static bool IsKnightCorrect(string start, string end)
        {
            int dx = Math.Abs(end[0] - start[0]);
            int dy = Math.Abs(end[1] - start[1]);

            return dx + dy == 3 && dx * dy == 2;
        }

        public static bool IsPawnCorrect(string start, string end)
        {
            return (end[0] - start[0] == 0 && end[1] - start[1] == 1);
        }

        public static bool IsRookCorrect(string start, string end)
        {
            return (end[0] == start[0] && end[1] != start[1] || end[0] != start[0] && end[1] == start[1]);
        }

        public static bool IsBishopCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]));
        }

        public static bool IsQueenCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) == Math.Abs(start[1] - end[1]) || end[0] == start[0] && end[1] != start[1] || end[0] != start[0] && end[1] == start[1]);
        }

        public static bool IsKingCorrect(string start, string end)
        {
            return (Math.Abs(start[0] - end[0]) <= 1 && Math.Abs(start[1] - end[1]) <= 1);
        }

        public static bool RecognitionFigureInCell(Cell[,] cell, string start)
        {
            if ((cell[start[0] - 48, start[1] - 48]).Role == Roles.V)
                return false;
            else
                return true;
        }
    }
}
