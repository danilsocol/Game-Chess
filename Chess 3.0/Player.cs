using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_3._0
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; } = 0;


        public Player(string name)
        {
            Name = name;
        }
        public void AddPoints(string role)
        {
            switch (role)
            {
                case "P":
                    Score += 10;
                    break;
                case "R":
                    Score += 20;
                    break;
                case "H":
                    Score += 20;
                    break;
                case "B":
                    Score += 20;
                    break;
                case "Q":
                    Score += 50;
                    break;
                case "K":
                    Score += 100;
                    break;
                default:
                    break;
            }
        }

    }
}
