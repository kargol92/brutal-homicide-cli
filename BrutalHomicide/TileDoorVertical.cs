namespace BrutalHomicide
{
    class TileDoorVertical : TileDoor
    {
        public TileDoorVertical(int x, int y) : base()
        {
            mark = '|';
            isOpen = false;
            this.x = x;
            this.y = y;
        }
    }
}
