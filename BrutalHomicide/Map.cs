using System;

namespace BrutalHomicide
{
    class Map
    {
        public Tile[,] Tiles { get { return tiles; } }
        public int Height { get { return height; } }
        public Map()
        {
            tiles = new Tile[height, width];
            table = new char[height, width] // table is only for first draw, later it's not using
                                    // it's easier to do map like this
            {
                { '#','#','#','#','#','#','#','#','#','#',  '#','#','#','#','#','#','#','#','#','#' },
                { '#',' ',' ',' ',' ','|',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#','#','#','o','o','#',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#','+','#','o','*','#',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ','%',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#','-','#','#','-','#',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },

                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                //{ '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#','#','#','#','#','#','#','#','#','#',  '#','#','#','#','#','#','#','#','#','#' }
            };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (table[y, x] == ' ')
                    {
                        tiles[y, x] = new Tile(x, y, TileType.blank);
                    }
                    if (table[y, x] == '#')
                    {
                        tiles[y, x] = new Tile(x, y, TileType.baseWall);
                    }
                    if (table[y, x] == '|')
                    {
                        tiles[y, x] = new Door(x, y, TileType.verticalDoor);
                    }
                    if (table[y, x] == '-')
                    {
                        tiles[y, x] = new Door(x, y, TileType.horizontalDoor);
                    }
                    if (table[y, x] == '%')
                    {
                        tiles[y, x] = new Wall(x, y, TileType.wall);
                    }
                    if (table[y, x] == '+')
                    {
                        tiles[y, x] = new Item(x, y, TileType.firstAid);
                    }
                    if (table[y, x] == 'o')
                    {
                        tiles[y, x] = new Item(x, y, TileType.grenade);
                    }
                    if (table[y, x] == '$')
                    {
                        tiles[y, x] = new Item(x, y, TileType.money);
                    }
                    if (table[y, x] == '*')
                    {
                        tiles[y, x] = new Item(x, y, TileType.ammo);
                    }
                }
            }
        }
        public void Draw(Player p1)
        {
            Console.SetCursorPosition(0, 0);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //if (tiles[y, x].type == Type.player)
                    //{
                    if (p1.X == x && p1.Y == y)
                    {
                        //p1.X = x;
                        //p1.Y = y;
                        if (p1.Direction == Direction.up)
                        {
                            Console.Write('▲');
                        }
                        if (p1.Direction == Direction.down)
                        {
                            Console.Write('▼');
                        }
                        if (p1.Direction == Direction.left)
                        {
                            Console.Write('◀');
                        }
                        if (p1.Direction == Direction.right)
                        {
                            Console.Write('▶');
                        }
                        continue;
                    }
                    
                    //}
                    if (tiles[y, x].type == TileType.blank)
                    {
                        Console.Write(' ');
                    }
                    if (tiles[y, x].type == TileType.baseWall)
                    {
                        Console.Write('#');
                    }
                    if (tiles[y, x].type == TileType.verticalDoor)
                    {
                        Console.Write('|');
                    }
                    if (tiles[y, x].type == TileType.horizontalDoor)
                    {
                        Console.Write('-');
                    }
                    if (tiles[y, x].type == TileType.wall)
                    {
                        Console.Write('&');
                    }
                    if (tiles[y, x].type == TileType.firstAid)
                    {
                        Console.Write('+');
                    }
                    if (tiles[y, x].type == TileType.grenade)
                    {
                        Console.Write('o');
                    }
                    if (tiles[y, x].type == TileType.money)
                    {
                        Console.Write('$');
                    }
                    if (tiles[y, x].type == TileType.ammo)
                    {
                        Console.Write('%');
                    }
                }
                Console.WriteLine();
            }
        }
        const int width = 20;
        const int height = 10;

        Tile[,] tiles;
        char[,] table;
    }
}
