using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : RoadTile
{
    [SerializeField] float TimeBetweenSpawn;
    [SerializeField] EnemyFactory _factory;

    private void Start()
    {
        _factory = GameBootStrapper.Instance.GetEnemyFactory();
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            yield return new WaitForSeconds(TimeBetweenSpawn);
            CreateEnemy();
        }
    }

    private void CreateEnemy()
    {
        AbstractEnemy enemy = _factory.CreateEnemy(AbstractEnemy.EnemyType.Base);
        enemy.transform.position = new Vector3(this.transform.position.x, transform.position.y + 3f, this.transform.position.z);
       
    }
}
