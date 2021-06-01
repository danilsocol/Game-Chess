using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Chess_3._0
{
    public enum Roles
    {
        V, P, R, H, B, K, Q
    }
    public enum Colors
    {
        V, Black, White
    }
    public class ModelBoard
    {
        public Cell[,] cell = new Cell[8, 8];
        public static Player PlayerOne { get; set; }
        public static Player PlayerTwo { get; set; }

        public void PlacementOfFigureNewGame()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    cell[i, j] = new Cell(Roles.V, Colors.V);// пустато
                }
            }

            for (int i = 0; i < 8; i++)
            {
                cell[i, 1] = new Cell(Roles.P, Colors.Black);// пешка
                cell[i, 6] = new Cell(Roles.P, Colors.White);
            }

            cell[0, 0] = new Cell(Roles.R, Colors.Black);// Башня
            cell[0, 7] = new Cell(Roles.R, Colors.White);
            cell[7, 0] = new Cell(Roles.R, Colors.Black);// Башня
            cell[7, 7] = new Cell(Roles.R, Colors.White);

            cell[1, 0] = new Cell(Roles.H, Colors.Black);// конь
            cell[1, 7] = new Cell(Roles.H, Colors.White);
            cell[6, 0] = new Cell(Roles.H, Colors.Black);// конь
            cell[6, 7] = new Cell(Roles.H, Colors.White);

            cell[2, 0] = new Cell(Roles.B, Colors.Black);// слон
            cell[2, 7] = new Cell(Roles.B, Colors.White);
            cell[5, 0] = new Cell(Roles.B, Colors.Black);// слон
            cell[5, 7] = new Cell(Roles.B, Colors.White);

            cell[3, 0] = new Cell(Roles.Q, Colors.Black);// КОРОЛЕВА
            cell[3, 7] = new Cell(Roles.Q, Colors.White);

            cell[4, 0] = new Cell(Roles.K, Colors.Black);// КОРОЛь
            cell[4, 7] = new Cell(Roles.K, Colors.White);
        }
        private void ReadNameAndScoreFromFile()
        {
            string[] namesAndScore = (File.ReadAllText("Save\\SavePlayer.txt")).Split(' ');

            ModelBoard.PlayerOne = new Player(namesAndScore[0]);
            ModelBoard.PlayerTwo = new Player(namesAndScore[2]);
            PlayerOne.Score = Convert.ToInt32(namesAndScore[1]);
            PlayerTwo.Score = Convert.ToInt32(namesAndScore[3]);
        }
        public void PlacementOfFigureContinue()
        {
            ReadNameAndScoreFromFile();

            string[] fieldInText = File.ReadAllLines("Save\\SaveBoard.txt");
            string[,] board = new string[8,8];

            for (int i = 0; i < 8; i++)
            {
                string[] a = fieldInText[i].Split(' ');

                for (int j = 0; j < 8; j++)
                {
                    board[i,j] = a[j];
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < fieldInText.Length; j++)
                {
                    switch (board[j,i][0])
                    {
                        case 'P':
                            cell[i, j] = new Cell(Roles.P, Colors.Black);
                            break;
                        case 'R':
                            cell[i, j] = new Cell(Roles.R, Colors.Black);
                            break;
                        case 'H':
                            cell[i, j] = new Cell(Roles.H, Colors.Black);
                            break;
                        case 'B':
                            cell[i, j] = new Cell(Roles.B, Colors.Black);
                            break;
                        case 'Q':
                            cell[i, j] = new Cell(Roles.Q, Colors.Black);
                            break;
                        case 'K':
                            cell[i, j] = new Cell(Roles.K, Colors.Black);
                            break;
                        default:
                            cell[i, j] = new Cell(Roles.V, Colors.V);
                            break;
                    }
                    if (board[j, i][1] == 'R')
                        cell[i, j].Color = Colors.White;
                }
            }
        }

        private void MakeMove()
        {

        }
    }
}
