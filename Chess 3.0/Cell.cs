using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_3._0
{
    public class Cell
    {
        public Colors Color { get; }
        public Roles Role { get; }
        public Cell(Roles role, Colors color)
        {
            Role = role;
            Color = color;
        }
    }
}
