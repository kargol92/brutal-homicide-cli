using System;
namespace BrutalHomicide
{
    class TileGrenade : Tile
    {
        public TileGrenade(int x, int y)
        {
            mark = 'o';
            color = ConsoleColor.DarkGreen;
            this.x = x;
            this.y = y;
        }
    }
}
