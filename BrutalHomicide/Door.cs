using System;

namespace BrutalHomicide
{
    class Door : Tile
    {
        public Door(int x, int y, TileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            isOpen = false;
        }

        public void checkOwner()
        {
            if (Math.Abs(owner.X - x) <= 2 && Math.Abs(owner.Y - y) <= 2)
            {
                isOpen = true;
            }
            else isOpen = false;
        }

        public void changeState()
        {

        }

        bool isOpen;
        Player owner;
    }
}
