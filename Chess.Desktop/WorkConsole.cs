using Chess_3._0;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Desktop
{
    class WorkConsole
    {
        public static void ReadMenu(int menuSelect)
        {
            int menuCounter = 0;

            ReadFream("   Chess   ", menuSelect, menuCounter);
            Console.WriteLine("\n");
            menuCounter++;

            ReadFream(" Новая игра ", menuSelect, menuCounter);
            Console.WriteLine("");
            menuCounter++;

            ReadFream(" Продолжить ", menuSelect, menuCounter);
            Console.WriteLine("");
            menuCounter++;

            ReadFream(" Рейтинг    ", menuSelect, menuCounter);
            Console.WriteLine("");
            menuCounter++;

            ReadFream(" Выход      ", menuSelect, menuCounter);
            Console.WriteLine("");
        }
        private static void ReadFream(string text, int menuSelect, int menuCounter)
        {
            int numSpace = 50;

            string line = "";
            for (int i = 0; i < text.Length; i++)
                line += '═';

            CreateSpace(numSpace, menuSelect, menuCounter);
            DrawCell('╔', line, '╗');

            CreateSpace(numSpace, menuSelect, menuCounter);
            DrawCell('║', text, '║');

            CreateSpace(numSpace, menuSelect, menuCounter);
            DrawCell('╚', line, '╝');
        }

        private static void DrawCell(char oneChar, string text, char twoChar)
        {
            Console.Write(oneChar);
            Console.Write(text);
            Console.WriteLine(twoChar);

            Console.ResetColor();
        }
        private static void CreateSpace(int numSpace, int menuSelect, int menuCounter)
        {
            for (int i = 0; i < numSpace; i++)
                Console.Write(" ");

            if (menuSelect == menuCounter)
                Console.BackgroundColor = ConsoleColor.Red;
        }
        public static string ReadName()
        {
            Console.WriteLine("Введите имя первого игрока, а затем второго");
            return Console.ReadLine();
        }
        public static void WriteField(Cell[,] cell)
        {
            Console.SetCursorPosition(0, 0);
            WriteFieldLine("┌", "─", "┬", "┐", 8);
            Console.WriteLine();

            for (int y = 0; y < 8; y++)
            {
                Console.Write('│');
                for (int x = 0; x < 8; x++)
                {
                    Console.Write(" ");

                    if (cell[x, y].Role == Roles.V)
                    {
                        Console.Write (" ");
                    }
                    else
                    {
                        if (cell[x, y].Color == Colors.Black)
                            Console.ForegroundColor = ConsoleColor.Red;
                        else
                            Console.ForegroundColor = ConsoleColor.Blue;

                        Console.Write($"{Convert.ToString(cell[x, y].Role)}");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(" │");
                }
                Console.WriteLine();

                WriteFieldLine("├", "─", "┼", "┤", 8);
                Console.WriteLine();
            }
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            WriteFieldLine("└", "─", "┴", "┘", 8);

        }
        private static void WriteFieldLine(string char1, string char2, string char3, string char4, int num)
        {
            Console.Write(char1 + char2 + char2 + char2);

            for (int i = 0; i < num - 1; i++)
                Console.Write(char3 + char2 + char2 + char2);

            Console.Write(char4);
        }

        public static void Error()
        {
            Console.Clear();
            Console.WriteLine("Ошибка");
        }

        public static void WriteChoiceCell(int[] selectCell, int[] pastSelectCell, Cell[,] cell)
        {
            Console.SetCursorPosition(pastSelectCell[0] * 4 + 2, pastSelectCell[1] * 2 + 1);

            Console.BackgroundColor = ConsoleColor.Black;
            if (cell[pastSelectCell[0], pastSelectCell[1]].Role != Roles.V)
            {
                if (cell[pastSelectCell[0], pastSelectCell[1]].Color == Colors.Black)
                    Console.ForegroundColor = ConsoleColor.Red;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write($"{cell[pastSelectCell[0], pastSelectCell[1]].Role}");
            }
            else
                Console.Write(" ");
            Console.ResetColor();


            Console.SetCursorPosition(selectCell[0] * 4 + 2, selectCell[1] * 2 + 1);

            Console.BackgroundColor = ConsoleColor.Red;
            if(cell[selectCell[0], selectCell[1]].Role != Roles.V)
                Console.Write($"{cell[selectCell[0], selectCell[1]].Role}");
            else
                Console.Write(" ");
            Console.ResetColor();

            pastSelectCell[0] = selectCell[0];
            pastSelectCell[1] = selectCell[1];
        }
    }
}
