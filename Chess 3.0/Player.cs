using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_3._0
{
    public class Player
    {
        public string Name { get; }
        public int CountPoints { get; set; } = 0;

        public Player(string name)
        {
            Name = name;
        }
        public void AddPoints(string role)
        {
            switch (role)
            {
                case "P":
                    CountPoints += 10;
                    break;
                case "R":
                    CountPoints += 20;
                    break;
                case "H":
                    CountPoints += 20;
                    break;
                case "B":
                    CountPoints += 20;
                    break;
                case "Q":
                    CountPoints += 50;
                    break;
                case "K":
                    CountPoints += 100;
                    break;
                default:
                    break;
            }
        }

    }
}
