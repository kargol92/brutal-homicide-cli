using System;

namespace BrutalHomicide
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            new Menu().run();
            Console.CursorVisible = true;
        }
    }
}
