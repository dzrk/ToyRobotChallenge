using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotChallenge
{
    public class Board
    {
        // properties of board
        int length;
        int height;

        public Board(int x = 5, int y = 5)
        {
            length = x;
            height = y;
        }

        public int Length { get => length; set => length = value; }
        public int Height { get => height; set => height = value; }
    }
}
