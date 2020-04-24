using System;
namespace BrutalHomicide
{
    class TileAmmo : Tile
    {
        public TileAmmo(int x, int y)
        {
            mark = '%';
            color = ConsoleColor.DarkGreen;
            this.x = x;
            this.y = y;
        }
    }
}
