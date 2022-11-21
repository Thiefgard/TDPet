using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : AbstractEnemy, IDamagable
{
    [SerializeField] private EnemyType _enemyType;

    
    public void GetDamage(int damage)
    {
        Health = Mathf.Clamp(Health - damage, 0, MaxHealth);
        if(Health == 0)
        {
            Death();
        }
    }

    public void Death()
    {
        factory.Reclaim(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        RoadTile road = collision.gameObject.GetComponent<RoadTile>();
        DestinationTile destination = collision.gameObject.GetComponent<DestinationTile>();
        if (road != null)
        {
            RoadTile = road;
        }
        if(destination != null)
        {
            factory.Reclaim(this);
        }
        
    }
}
