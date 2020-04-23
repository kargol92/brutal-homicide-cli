namespace BrutalHomicide
{
    class Wall : Tile
    {
        public int Health
        {
            get { return health; }
        }
        public Wall(int x, int y, eTileType type)
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
        int health;
        bool isDestroyed;
    }
}
