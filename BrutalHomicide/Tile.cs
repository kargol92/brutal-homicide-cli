namespace BrutalHomicide
{
    class Tile
    {
        public TileType type;
        public Tile() { }
        public Tile(int x, int y, TileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        protected int x;
        protected int y;
    }
}
