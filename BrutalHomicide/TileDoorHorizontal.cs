namespace BrutalHomicide
{
    class TileDoorHorizontal : TileDoor
    {
        public TileDoorHorizontal(int x, int y) : base()
        {
            mark = '-';
            isOpen = false;
            this.x = x;
            this.y = y;
        }
    }
}
