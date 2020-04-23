namespace BrutalHomicide
{
    class Bullet
    {
        public Bullet(int x, int y, Direction direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }

        public void translocate()
        {
            if (direction == Direction.up) y--;
            if (direction == Direction.down) y++;
            if (direction == Direction.left) x--;
            if (direction == Direction.right) x++;
        }

        public bool checkCollision()
        {
            //if (
            return false;
        }

        Direction direction;
        int x;
        int y;
    }
}
