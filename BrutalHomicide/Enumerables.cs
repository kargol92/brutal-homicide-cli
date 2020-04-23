namespace BrutalHomicide
{
    enum Direction
    {
        up, down, left, right
    }
    enum TileType // player is temporary only for ascii version
    {
        player, blank, wall, baseWall, verticalDoor, horizontalDoor, item, firstAid, ammo, grenade, money
    }
    enum ItemType
    {
        grenade,
        firstAid,
        money,
        ammo
    }
}
