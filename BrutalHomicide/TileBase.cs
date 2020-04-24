using System;
namespace BrutalHomicide
{
    class TileBase : Tile
    {
        public TileBase(int x, int y)
        {
            mark = '#';
            color = ConsoleColor.White;
            this.x = x;
            this.y = y;
        }
    }
}
