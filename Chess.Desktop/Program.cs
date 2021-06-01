using Chess.Desktop;
using System;

namespace Chess_3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            int menuSelect = 1;

            WorkConsole.ReadMenu(menuSelect);
            Selection(menuSelect);
        }
        static void Selection(int selectCell)
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                if (key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    switch (selectCell)
                    {
                        case 1:
                            GameActionsConsole.GameActions();
                            break;

                        case 2:

                            break;

                        case 3:

                            break;

                        case 4:

                            break;
                    }
                    break;
                }
                if (key == ConsoleKey.W || key == ConsoleKey.UpArrow)
                    if (selectCell != 1)
                        selectCell -= 1;

                if (key == ConsoleKey.S || key == ConsoleKey.DownArrow)
                    if (selectCell != 4)
                        selectCell += 1;

                Console.Clear();
                WorkConsole.ReadMenu(selectCell);
            }
        }
        //public static void CreateUser(Player User)
        //{
        //    do
        //    {
        //        User.Name = WorkConsole.ReadName();
        //        Console.Clear();

        //    } while (User.Name.Length == 0);
        //}
        //public static void GameActions()
        //{
        //    int[] selectCell = { 0, 0 };
        //    int[] pastSelectCell = { 0, 0 };
        //    string[] movementOfTheFigures = new string[2];

        //    Cell[,] board = new Cell[8, 8];

        //    //while (true)
        //    //{
        //    //    WorkConsole.WriteField(board);

        //    //   SelectCell(selectCell, board, pastSelectCell, movementOfTheFigures);

        //    //    MakeMove(movementOfTheFigures, board);
        //    //}
        //}

        //public static void MakeMove(string[] move, string[,] cell)
        //{
        //    string start = move[0];

        //    if (!FigureMove.RecognitionFigureInCell(cell, start))
        //        WorkConsole.Error();

        //    string end = move[1];

        //    bool isCorrect = FigureMove.CheckCorrectOfTheMove(cell, start, end);

        //    int StartHorizontalCood = start[1] - 48;
        //    int StartVerticalCoord = start[0] - 48;

        //    int EndHorizontalCood = end[1] - 48;
        //    int EndVerticalCoord = end[0] - 48;

        //    if (isCorrect)
        //    {
        //        string pickFigure = cell[StartVerticalCoord, StartHorizontalCood];
        //        cell[StartVerticalCoord, StartHorizontalCood] = null;
        //        cell[EndVerticalCoord, EndHorizontalCood] = pickFigure;
        //    }
        //    else
        //        WorkConsole.Error();
        //}

        //public static void SelectCell(int[] selectCell, string[,] cell, int[] pastSelectCell, string[] movementOfTheFigures)
        //{
        //    bool IsTheFigureSelected = true;

        //    while (true)
        //    {
        //        ConsoleKey key = Console.ReadKey().Key;

        //        if (key == ConsoleKey.DownArrow && selectCell[1] < 7) selectCell[1]++;
        //        if (key == ConsoleKey.UpArrow && selectCell[1] > 0) selectCell[1]--;
        //        if (key == ConsoleKey.RightArrow && selectCell[0] < 7) selectCell[0]++;
        //        if (key == ConsoleKey.LeftArrow && selectCell[0] > 0) selectCell[0]--;

        //        WorkConsole.WriteChoiceCell(selectCell, cell, pastSelectCell);


        //        if (key == ConsoleKey.Enter && !IsTheFigureSelected)
        //        {
        //            movementOfTheFigures[1] = $"{selectCell[0]}{selectCell[1]}";
        //            break;
        //        }

        //        if (key == ConsoleKey.Enter && IsTheFigureSelected && FigureMove.RecognitionFigureInCell(cell, $"{selectCell[0]}{selectCell[1]}"))
        //        {
        //            movementOfTheFigures[0] = $"{selectCell[0]}{selectCell[1]}";
        //            IsTheFigureSelected = false;
        //        }
        //    }
        //}
    }
}