using System;
namespace BrutalHomicide
{
    class TileMoney : Tile
    {
        public TileMoney(int x, int y)
        {
            mark = 'o';
            color = ConsoleColor.DarkGreen;
            this.x = x;
            this.y = y;
        }
    }
}
