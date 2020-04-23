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
                player1.PressedKey = checkKey();
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

        ConsoleKey checkKey()
        {
            pressedKey = Console.ReadKey().Key;
            Console.WriteLine("pressedKey=" + pressedKey);
            if (pressedKey == ConsoleKey.Escape)
                isRunning = false;
            return pressedKey;
        }

        bool isRunning;
        ConsoleKey pressedKey;
        Map map;
        Player player1;

        bool checkCollisions(Map map, Player p1)
        {
            if (map.Tiles[p1.YNextStep, p1.XNextStep].type == TileType.baseWall) return true;
            if (map.Tiles[p1.YNextStep, p1.XNextStep].type == TileType.wall) return true;
            return false;
        }
        bool checkItems()
        {
            if (map.Tiles[player1.Y, player1.X].type == TileType.grenade)
            {
                player1.takeItem(TileType.grenade);
                map.Tiles[player1.Y, player1.X].type = TileType.blank;
                return true;
            }
            if (map.Tiles[player1.Y, player1.X].type == TileType.ammo)
            {
                player1.takeItem(TileType.ammo);
                map.Tiles[player1.Y, player1.X].type = TileType.blank;
                return true;
            }
            if (map.Tiles[player1.Y, player1.X].type == TileType.firstAid)
            {
                player1.takeItem(TileType.firstAid);
                map.Tiles[player1.Y, player1.X].type = TileType.blank;
                return true;
            }
            if (map.Tiles[player1.Y, player1.X].type == TileType.money)
            {
                player1.takeItem(TileType.money);
                map.Tiles[player1.Y, player1.X].type = TileType.blank;
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
