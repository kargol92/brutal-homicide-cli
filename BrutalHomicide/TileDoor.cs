using System;

namespace BrutalHomicide
{
    class TileDoor : Tile
    {
        public TileDoor()
        {
            color = ConsoleColor.White;
        }

        public void checkOwner()
        {
            if (Math.Abs(owner.x - x) <= 2 && Math.Abs(owner.y - y) <= 2)
            {
                isOpen = true;
            }
            else isOpen = false;
        }

        public void changeState()
        {

        }

        protected bool isOpen;
        protected Player owner;
    }
}
