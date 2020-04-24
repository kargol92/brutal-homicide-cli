using System;
using System.Media;

namespace BrutalHomicide
{
    enum Direction
    {
        up, down, left, right
    }

    class Player
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public int xNextStep { get; private set; }
        public int yNextStep { get; private set; }
        public bool inMotion;
        public Direction direction { get; private set; }

        public Player()
        {
            x = 1;
            y = 1;
            xNextStep = 10;
            yNextStep = 10;
            inMotion = false;
            direction = Direction.right;
            health = 50;
            ammo = 0;
            grenades = 0;
        }

        public void writePosition()
        {
            n = 0;
            Console.SetCursorPosition(n, Map.height + 2);
            Console.WriteLine("in motion=" + inMotion + " ");
            Console.SetCursorPosition(n, Map.height + 3);
            Console.WriteLine("direction=" + direction + " ");
            Console.SetCursorPosition(n, Map.height + 4);
            Console.WriteLine("x=" + x + " ");
            Console.SetCursorPosition(n, Map.height + 5);
            Console.WriteLine("y=" + y + " ");
            Console.SetCursorPosition(n, Map.height + 6);
            Console.WriteLine("xNextStep=" + xNextStep + " ");
            Console.SetCursorPosition(n, Map.height + 7);
            Console.WriteLine("yNextStep=" + yNextStep + " ");

        }

        public void tryMove(Direction direction)
        {
            inMotion = true;
            this.direction = direction;
            xNextStep = x;
            yNextStep = y;

            if (direction == Direction.up)      yNextStep = y - 1;
            if (direction == Direction.down)    yNextStep = y + 1;
            if (direction == Direction.left)    xNextStep = x - 1;
            if (direction == Direction.right)   xNextStep = x + 1;
        }

        public void makeMove()
        {

            if (direction == Direction.up)
                y--;
            if (direction == Direction.down)
                y++;
            if (direction == Direction.left)
                x--;
            if (direction == Direction.right)
                x++;
        }

        public void showBackpack()
        {
            n = 0;
            Console.SetCursorPosition(n, Map.height + 8);
            Console.WriteLine("Health: " + health);
            Console.SetCursorPosition(n, Map.height + 9);
            Console.WriteLine("Ammo: " + ammo);
            Console.SetCursorPosition(n, Map.height + 10);
            Console.WriteLine("Granades: " + grenades);
        }

        public void takeItem(Tile item)
        {
            if (item is TileGrenade)
            {
                grenades++;
                SystemSounds.Exclamation.Play();
                //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"audio/confirmation_001.ogg");
                //player.Play();
            }
            if (item is TileFirstAid)
            {
                health += 50;
                SystemSounds.Question.Play();
            }
            if (item is TileAmmo)
            {
                ammo += 25;
                SystemSounds.Hand.Play();
            }
            if (item is TileMoney)
            {
                money += 50;
                SystemSounds.Asterisk.Play();
            }
        }



        int n;
        int grenades;
        int health;
        int ammo;
        int money;

        
        public void openDoor(char[,] map)
        {
            if (x == 4 && y == 1) map[1,5] = '+';
        }

        public void shoot()
        {
            new Bullet(x, y, direction);
        }

        public void throwGrenade()
        {
            if (grenades > 0)
            {
                grenades--;
                //new Grenade(x, y);
            }
        }
    }
}
