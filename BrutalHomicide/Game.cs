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
                //p1.checkKey();
                if (checkPressedKeys() == player1)
                    player1.PressedKey = pressedKey;
                player1.TryMove();
                if (checkCollisions(map, player1) == false)
                    player1.MakeMove();
                checkItems();
                checkDoor();
            }
        }

        void display()
        {
            player1.WritePosition(map);
            player1.ShowBackpack(map);
            map.Draw(player1);
        }

        void checkKey()
        {

        }

        bool isRunning;
        ConsoleKey pressedKey;

        Map map;
        Player player1;

        Player checkPressedKeys()
        {
            pressedKey = Console.ReadKey().Key;

            Console.WriteLine("pressedKey=" + pressedKey);
            if (pressedKey == ConsoleKey.Escape)
            {
                isRunning = false;
                return null;
            }
            if (pressedKey == ConsoleKey.UpArrow)
                return player1;
            if (pressedKey == ConsoleKey.DownArrow)
                return player1;
            if (pressedKey == ConsoleKey.LeftArrow)
                return player1;
            if (pressedKey == ConsoleKey.RightArrow)
                return player1;
            if (pressedKey == ConsoleKey.Spacebar)
                return player1;

            return null;
        }
        bool checkCollisions(Map map, Player p1)
        {
            if (map.Tiles[p1.YNextStep, p1.XNextStep].Type == eTileType.baseWall) return true;
            if (map.Tiles[p1.YNextStep, p1.XNextStep].Type == eTileType.wall) return true;
            return false;
        }
        bool checkItems()
        {
            if (map.Tiles[player1.Y, player1.X].Type == eTileType.grenade)
            {
                player1.takeItem(eTileType.grenade);
                map.Tiles[player1.Y, player1.X].Type = eTileType.blank;
                return true;
            }
            if (map.Tiles[player1.Y, player1.X].Type == eTileType.ammo)
            {
                player1.takeItem(eTileType.ammo);
                map.Tiles[player1.Y, player1.X].Type = eTileType.blank;
                return true;
            }
            if (map.Tiles[player1.Y, player1.X].Type == eTileType.firstAid)
            {
                player1.takeItem(eTileType.firstAid);
                map.Tiles[player1.Y, player1.X].Type = eTileType.blank;
                return true;
            }
            if (map.Tiles[player1.Y, player1.X].Type == eTileType.money)
            {
                player1.takeItem(eTileType.money);
                map.Tiles[player1.Y, player1.X].Type = eTileType.blank;
                return true;
            }
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
