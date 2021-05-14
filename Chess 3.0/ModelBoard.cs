using System;
using System.Collections.Generic;
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
    }
}
