using System;

namespace BrutalHomicide
{
    class Map
    {
        public Tile[,] tiles { get; private set; }

        const int width = 20;
        public const int height = 10;

        public Map()
        {
            tiles = new Tile[height, width];
            table = new char[height, width] // table is only for first draw, later it's not using
                                    // it's easier to do map like this
            {
                { '#','#','#','#','#','#','&','&','&','&',  '&','&','&','&','&','&','&','&','&','&' },
                { '#',' ',' ',' ',' ','|',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '#','#','#','o','o','#',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '#','+','#','o','%','#',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '#',' ',' ',' ',' ','&',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '#','-','#','#','-','#',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },

                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                //{ '&',' ',' ',' ',' ',' ',' ',' ',' ',' ',  ' ',' ',' ',' ',' ',' ',' ',' ',' ','&' },
                { '&','&','&','&','&','&','&','&','&','&',  '&','&','&','&','&','&','&','&','&','&' }
            };

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (table[y, x] == ' ') tiles[y, x] = new TileBlank(x, y);
                    if (table[y, x] == '&') tiles[y, x] = new TileWall(x, y);
                    if (table[y, x] == '#') tiles[y, x] = new TileBase(x, y);
                    if (table[y, x] == '|') tiles[y, x] = new TileDoorVertical(x, y);
                    if (table[y, x] == '-') tiles[y, x] = new TileDoorHorizontal(x, y);
                    if (table[y, x] == '+') tiles[y, x] = new TileFirstAid(x, y);
                    if (table[y, x] == 'o') tiles[y, x] = new TileGrenade(x, y);
                    if (table[y, x] == '$') tiles[y, x] = new TileMoney(x, y);
                    if (table[y, x] == '%') tiles[y, x] = new TileAmmo(x, y);
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
                    if (p1.x == x && p1.y == y)
                    {
                        //p1.X = x;
                        //p1.Y = y;
                        if (p1.direction == Direction.up)       Console.Write('▲');
                        if (p1.direction == Direction.down)     Console.Write('▼');
                        if (p1.direction == Direction.left)     Console.Write('◀');
                        if (p1.direction == Direction.right)    Console.Write('▶');
                        continue;
                    }

                    tiles[y, x].display();
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }

        char[,] table;
    }
}
