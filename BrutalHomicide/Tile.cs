using System;

namespace BrutalHomicide
{
    class Tile
    {
        public ConsoleColor color;

        public Tile() { }
        public Tile(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void display()
        {
            Console.ForegroundColor = color;
            Console.Write(mark);
        }

        protected char mark;
        protected int x;
        protected int y;
    }
}
