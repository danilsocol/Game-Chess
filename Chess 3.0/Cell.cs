using System;
using System.Collections.Generic;
using System.Text;

namespace Chess_3._0
{
    public class Cell
    {
        public Colors Color { get; set; }
        public Roles Role { get; set; }
        public Cell(Roles role, Colors color)
        {
            Role = role;
            Color = color;
        }
    }
}
