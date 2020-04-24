using System;

namespace BrutalHomicide
{
    class TileWall : Tile
    {
        public int health { get; private set; }

        public TileWall(int x, int y)
        {
            mark = '&';
            color = ConsoleColor.DarkGray;
            health = 10;
            isDestroyed = false;
            this.x = x;
            this.y = y;
        }

        public void checkHealth()
        {
            if (health <= 0)
            {
                health = 0;
                isDestroyed = true;
            }
        }

        bool isDestroyed;
    }
}
