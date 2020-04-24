using System;
namespace BrutalHomicide
{
    class TileBlank : Tile
    {
        public TileBlank(int x, int y)
        {
            mark = ' ';
            color = ConsoleColor.White;
            this.x = x;
            this.y = y;
        }
    }
}
