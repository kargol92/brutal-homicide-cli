using System;

namespace BrutalHomicide
{
    class Player
    {
        public int X { get { return x; } }
        public int Y { get { return y; } }
        public int XNextStep { get { return xNextStep; } }
        public int YNextStep { get { return yNextStep; } }
        public ConsoleKey PressedKey { set { pressedKey = value; } }
        public eDirection Direction { get { return direction; } }

        public Player()
        {
            x = 1;
            y = 1;
            xNextStep = 10;
            yNextStep = 10;
            direction = eDirection.right;
            health = 50;
            ammo = 0;
            grenades = 0;
        }

        public void WritePosition(Map map)
        {
            n = 0;
            Console.SetCursorPosition(n, map.Height + 2);
            Console.WriteLine("x=" + x + " ");
            Console.SetCursorPosition(n, map.Height + 3);
            Console.WriteLine("y=" + y + " ");
            Console.SetCursorPosition(n, map.Height + 4);
            Console.WriteLine("xNextStep=" + xNextStep + " ");
            Console.SetCursorPosition(n, map.Height + 5);
            Console.WriteLine("yNextStep=" + yNextStep + " ");
            Console.SetCursorPosition(n, map.Height + 6);
            Console.WriteLine("direction=" + direction + " ");
        }

        //public void checkKey(ref bool running1)
        //{
        //    cki = Console.ReadKey();

        //    if (cki.Key == ConsoleKey.Escape) running1 = false;
        //    if (cki.Key == ConsoleKey.UpArrow) { direction = eDirection.up; }
        //    if (cki.Key == ConsoleKey.DownArrow) { direction = eDirection.down; }
        //    if (cki.Key == ConsoleKey.LeftArrow) { direction = eDirection.left; }
        //    if (cki.Key == ConsoleKey.RightArrow) { direction = eDirection.right; }
        //    if (cki.Key == ConsoleKey.Spacebar) shoot();
        //    if (cki.Key == ConsoleKey.F1) throwGrenade();
        //}

       
        public void TryMove()
        {
            xNextStep = x;
            yNextStep = y;
            if (pressedKey == ConsoleKey.UpArrow) { direction = eDirection.up; yNextStep = y - 1; }
            if (pressedKey == ConsoleKey.DownArrow) { direction = eDirection.down; yNextStep = y + 1; }
            if (pressedKey == ConsoleKey.LeftArrow) { direction = eDirection.left; xNextStep = x - 1; }
            if (pressedKey == ConsoleKey.RightArrow) { direction = eDirection.right; xNextStep = x + 1; }
            if (pressedKey == ConsoleKey.Spacebar) shoot();
        }

        public void MakeMove()
        {
            if (direction == eDirection.up)
                y--;
            if (direction == eDirection.down)
                y++;
            if (direction == eDirection.left)
                x--;
            if (direction == eDirection.right)
                x++;
        }

        public void ShowBackpack(Map map)
        {
            n = 0;
            Console.SetCursorPosition(n, map.Height + 7);
            Console.WriteLine("Health: " + health);
            Console.SetCursorPosition(n, map.Height + 8);
            Console.WriteLine("Ammo: " + ammo);
            Console.SetCursorPosition(n, map.Height + 9);
            Console.WriteLine("Granades: " + grenades);
        }

        public void takeItem(eTileType item)
        {
            if (item == eTileType.grenade) grenades++;
            if (item == eTileType.firstAid) health += 50;
            if (item == eTileType.ammo) ammo += 25;
            if (item == eTileType.money) money += 50;
        }


        ///////////
        // PRIVATES
        int n;
        ConsoleKey pressedKey;
        int x;
        int y;
        int xNextStep;
        int yNextStep;
        public eDirection direction;
        int grenades;
        int health;
        int ammo;
        int money;

        
        public void openDoor(char[,] map)
        {
            if (x == 4 && y == 1) map[1,5] = '+';
        }
        void shoot()
        {
            new Bullet(x, y, direction);
        }
        void throwGrenade()
        {
            if (grenades > 0)
            {
                grenades--;
                new Grenade(x, y);
            }
        }
    }
}
