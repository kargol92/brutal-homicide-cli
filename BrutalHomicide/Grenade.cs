namespace BrutalHomicide
{
    class Grenade
    {
        public Grenade(int x, int y)
        {
            this.x = x;
            this.y = y;
            isThrowed = true;
            this.time = 5;
        }
        int x;
        int y;
        bool isThrowed;
        int time;
    }
}
