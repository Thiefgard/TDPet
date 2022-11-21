using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTileBuilder : MonoBehaviour
{
    //Class for bulding or modifing tiles
    public AbstractTower Build(AbstractTower.TowerType type, TowerFactory factory, WallTile tile)
    {
        AbstractTower tower =  factory.CreateTower(type);
        tower.transform.parent = tile.transform;
        tower.transform.position = tile.transform.position;
        return tower;
    }

    public void DestroyBuild(AbstractTower tower)
    {
        tower.factory.Reclaim(tower);
    }
}
