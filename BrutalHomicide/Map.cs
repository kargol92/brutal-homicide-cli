using System;

namespace BrutalHomicide
{
    class Map
    {
        public Tile[,] Tiles { get { return tiles; } }
        public int Height { get { return height; } }
        public Map()
        {
            width = 20;
            height = 20;
            tiles = new Tile[20, 20];
            table = new char[20, 20] // table is only for first draw, later it's not using
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
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },

                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','#' },
                { '#','#','#','#','#','#','#','#','#','#',  '#','#','#','#','#','#','#','#','#','#' }
            };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (table[y, x] == ' ')
                    {
                        tiles[y, x] = new Tile(x, y, eTileType.blank);
                    }
                    if (table[y, x] == '#')
                    {
                        tiles[y, x] = new Tile(x, y, eTileType.baseWall);
                    }
                    if (table[y, x] == '|')
                    {
                        tiles[y, x] = new Door(x, y, eTileType.verticalDoor);
                    }
                    if (table[y, x] == '-')
                    {
                        tiles[y, x] = new Door(x, y, eTileType.horizontalDoor);
                    }
                    if (table[y, x] == '%')
                    {
                        tiles[y, x] = new Wall(x, y, eTileType.wall);
                    }
                    if (table[y, x] == '+')
                    {
                        tiles[y, x] = new Item(x, y, eTileType.firstAid);
                    }
                    if (table[y, x] == 'o')
                    {
                        tiles[y, x] = new Item(x, y, eTileType.grenade);
                    }
                    if (table[y, x] == '$')
                    {
                        tiles[y, x] = new Item(x, y, eTileType.money);
                    }
                    if (table[y, x] == '*')
                    {
                        tiles[y, x] = new Item(x, y, eTileType.ammo);
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
                        if (p1.Direction == eDirection.up)
                        {
                            Console.Write('▲');
                        }
                        if (p1.Direction == eDirection.down)
                        {
                            Console.Write('▼');
                        }
                        if (p1.Direction == eDirection.left)
                        {
                            Console.Write('◀');
                        }
                        if (p1.Direction == eDirection.right)
                        {
                            Console.Write('▶');
                        }
                        continue;
                    }
                    
                    //}
                    if (tiles[y, x].Type == eTileType.blank)
                    {
                        Console.Write(' ');
                    }
                    if (tiles[y, x].Type == eTileType.baseWall)
                    {
                        Console.Write('#');
                    }
                    if (tiles[y, x].Type == eTileType.verticalDoor)
                    {
                        Console.Write('|');
                    }
                    if (tiles[y, x].Type == eTileType.horizontalDoor)
                    {
                        Console.Write('-');
                    }
                    if (tiles[y, x].Type == eTileType.wall)
                    {
                        Console.Write('&');
                    }
                    if (tiles[y, x].Type == eTileType.firstAid)
                    {
                        Console.Write('+');
                    }
                    if (tiles[y, x].Type == eTileType.grenade)
                    {
                        Console.Write('o');
                    }
                    if (tiles[y, x].Type == eTileType.money)
                    {
                        Console.Write('$');
                    }
                    if (tiles[y, x].Type == eTileType.ammo)
                    {
                        Console.Write('%');
                    }
                }
                Console.WriteLine();
            }
        }
        int width;
        int height;

        Tile[,] tiles;
        char[,] table;
    }
}
