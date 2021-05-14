using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_3._0
{
    class Player
    {
        public string Name { get; }
        public int CountPoints { get; set; } = 0;
        public Player(string name)
        {
            Name = name;
        }
        public void AddPoints(Roles role)
        {
            switch (role)
            {
                case Roles.P:
                    CountPoints += 10;
                    break;
                case Roles.R:
                    CountPoints += 20;
                    break;
                case Roles.H:
                    CountPoints += 20;
                    break;
                case Roles.B:
                    CountPoints += 20;
                    break;
                case Roles.Q:
                    CountPoints += 50;
                    break;
                case Roles.K:
                    CountPoints += 100;
                    break;
                default:
                    break;
            }
        }

    }
}
