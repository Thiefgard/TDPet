using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCanonTower : MonoBehaviour, IButton
{
    [SerializeField] private WallTile _wallTile;
    private AbstractTower.TowerType type = AbstractTower.TowerType.Canon;

    public void GetTile(WallTile tile)
    {
        _wallTile = tile;
    }

    public void Create()
    {
        _wallTile.CreateTower(type);
    }

}
