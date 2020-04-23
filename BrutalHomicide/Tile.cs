using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrutalHomicide
{
    class Tile
    {
        public eTileType Type
        {
            get { return type; }
            set { type = value; }
        }
        public Tile() { }
        public Tile(int x, int y, eTileType type)
        {
            this.x = x;
            this.y = y;
            this.type = type;
        }

        protected int x;
        protected int y;
        protected eTileType type;
    }
}
