using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(menuName ="Factory/EnemyFactory")]
public class EnemyFactory : ScriptableObject
{
    [SerializeField] private AbstractEnemy _baseEnemyPrefab;
    [SerializeField] private AbstractEnemy _fastEnemyPrefab;



    public AbstractEnemy CreateEnemy(AbstractEnemy.EnemyType type)
    {
        switch (type)
        {
            case AbstractEnemy.EnemyType.Base:
                return Get(_baseEnemyPrefab);
            case AbstractEnemy.EnemyType.Fast:
                return Get(_fastEnemyPrefab);
        }
        return null;
    }

    public void Reclaim(AbstractEnemy enemy)
    {
        GameBootStrapper.Instance.GetTargetAnalyzer().RemoveEnemy(enemy);
        Destroy(enemy.gameObject);
    }

    private AbstractEnemy Get(AbstractEnemy prefab)
    {
        AbstractEnemy instance = Instantiate(prefab);
        instance.factory = this;
        GameBootStrapper.Instance.GetTargetAnalyzer().AddNewEnemy(instance);
        SceneManager.MoveGameObjectToScene(instance.gameObject, SceneManager.GetActiveScene());
        return instance;
    }
}
