using System;

namespace BrutalHomicide
{
    class Game
    {
        public Game()
        {
            isRunning = true;
            map = new Map();
            player1 = new Player();
        }

        public void run()
        {
            Console.Clear();
            while (isRunning)
            {
                display();
                getKey();
                if (player1.inMotion && !checkCollisions(map, player1))
                    player1.makeMove();
                checkItems();
                checkDoor();
            }
        }

        void display()
        {
            map.Draw(player1);
            player1.writePosition();
            player1.showBackpack();
        }

        void getKey()
        {
            pressedKey = Console.ReadKey().Key;
            Console.WriteLine("pressedKey=" + pressedKey);

            if (pressedKey == ConsoleKey.UpArrow ||
                pressedKey == ConsoleKey.DownArrow ||
                pressedKey == ConsoleKey.LeftArrow ||
                pressedKey == ConsoleKey.RightArrow)
                player1.inMotion = true;
            else
                player1.inMotion = false;

            if (pressedKey == ConsoleKey.UpArrow)       player1.tryMove(Direction.up);
            if (pressedKey == ConsoleKey.DownArrow)     player1.tryMove(Direction.down);
            if (pressedKey == ConsoleKey.LeftArrow)     player1.tryMove(Direction.left);
            if (pressedKey == ConsoleKey.RightArrow)    player1.tryMove(Direction.right);
            if (pressedKey == ConsoleKey.Spacebar)      player1.shoot();
            if (pressedKey == ConsoleKey.Escape)        isRunning = false;
        }

        bool isRunning;
        ConsoleKey pressedKey;
        Map map;
        Player player1;

        bool checkCollisions(Map map, Player p1)
        {
            if (map.tiles[p1.yNextStep, p1.xNextStep] is TileBase)
                return true;
            else if (map.tiles[p1.yNextStep, p1.xNextStep] is TileWall)
                return true;
            else
                return false;
        }

        bool checkItems()
        {
            Tile tile = map.tiles[player1.y, player1.x];
            if (tile is TileGrenade || tile is TileAmmo || tile is TileFirstAid || tile is TileMoney)
            {
                player1.takeItem(tile);
                map.tiles[player1.y, player1.x] = new TileBlank(player1.y, player1.x);
                return true;
            }
            else
                return false;
        }

        void checkDoor()
        {
            //if (map.Tiles[p1.Y, p1.X].Type == eTileType.horizontalDoor)
            //{
            //    p1.takeItem(eTileType.grenade);
            //    map.Tiles[p1.Y, p1.X].Type = eTileType.blank;
            //    //return true;
            //}
            //Tile door = map.Tiles[1, 5].
        }
    }
}
