using System;
namespace BrutalHomicide
{
    class TileFirstAid : Tile
    {
        public TileFirstAid(int x, int y)
        {
            mark = '+';
            color = ConsoleColor.Red;
            this.x = x;
            this.y = y;
        }
    }
}
