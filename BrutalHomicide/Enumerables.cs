namespace BrutalHomicide
{
    enum eDirection
    {
        up, down, left, right
    }
    enum eTileType // player is temporary only for ascii version
    {
        player, blank, wall, baseWall, verticalDoor, horizontalDoor, item, firstAid, ammo, grenade, money
    }
    enum eItemType
    {
        grenade,
        firstAid,
        money,
        ammo
    }
}
