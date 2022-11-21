using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractEnemy : MonoBehaviour
{
    public enum EnemyType
    {
        Base,
        Fast
    }
    public EnemyFactory factory;
    //EnemyMovementDistance from spawn point. Need for tower target by first enemy
    public float Distance = 0;
    public int MaxHealth;
    public int Health;
    public float Speed;
    //point for Movement
    public Transform Destination;
    //CurrentRoad
    public RoadTile RoadTile;
    //Get Destination transform for movement;
    public Transform NextTarget()
    {
        if (RoadTile != null)
        {
            return RoadTile.GetTileToMove();
        }
        return null;
    }
}
