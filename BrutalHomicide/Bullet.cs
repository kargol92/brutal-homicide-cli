namespace BrutalHomicide
{
    class Bullet
    {
        public Bullet(int x, int y, eDirection direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }
        public void Translocate()
        {
            if (direction == eDirection.up) y--;
            if (direction == eDirection.down) y++;
            if (direction == eDirection.left) x--;
            if (direction == eDirection.right) x++;
        }
        public bool CheckCollision()
        {
            //if (
            return false;
        }
        eDirection direction;
        int x;
        int y;
    }
}
