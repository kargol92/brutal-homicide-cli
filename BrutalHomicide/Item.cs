namespace BrutalHomicide
{
    class Item : Tile
    {
        //public eItemType ItemType { get { return itemType; } }
        public Item(int x, int y, eTileType tileType)
        {
            isCollected = false;
            this.x = x;
            this.y = y;
            this.type = tileType;
            //this.itemType = itemType;
        }
        bool isCollected;
        //eItemType itemType;
    }
}
