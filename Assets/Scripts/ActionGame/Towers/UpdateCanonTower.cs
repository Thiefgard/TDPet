using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCanonTower : MonoBehaviour, IButton
{
    private WallTile _wallTile;
    public void GetTile(WallTile tile)
    {
        _wallTile = tile;
    }

   
}
