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
        private static void Selection(int selectCell)
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
                            GameActionsConsole.Action();
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
      
    }
}