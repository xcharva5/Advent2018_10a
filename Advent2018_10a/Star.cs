using System;
using System.Collections.Generic;
using System.Text;

namespace Advent2018_10a
{
    class Star
    {
        public Values Position { get; set; }
        public Values Velocity { get; set; }

        public Star(int posX, int posY, int velX, int velY)
        {
            Position = new Values(posX, posY);
            Velocity = new Values(velX, velY);
        }

        public struct Values
        {
            public int x, y;

            public Values(int px, int py)
            {
                x = px;
                y = py;
            }
        }
    }
}
