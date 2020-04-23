namespace BrutalHomicide
{
    class Wall : Tile
    {
        public int health { get; private set; }
        public Wall(int x, int y, TileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
            health = 10;
            isDestroyed = false;
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
