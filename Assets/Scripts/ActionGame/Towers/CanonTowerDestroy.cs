using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTowerDestroy : MonoBehaviour, IButton
{
    private WallTile _tile;
    public void GetTile(WallTile tile)
    {
        _tile = tile;
    }

    public void DestroyCanonTower()
    {
        _tile.DestoyTower();
    }
}
