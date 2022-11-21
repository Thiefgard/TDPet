using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Collect all enemies at the scene, sort and return target from tower arrays
public class TargetAnalyzer : MonoBehaviour
{
    [SerializeField] private List<AbstractEnemy> _activeEnemies;

   //retyrn enemy for tower
    public AbstractEnemy GetEnemyTarget(List<AbstractEnemy> enemies, AbstractTower.TowerFireMode fireMode)
    {
        AbstractEnemy enemy;
        if (fireMode == AbstractTower.TowerFireMode.First)
        {
            enemy = GetFirstEnemy(TowerTargets(enemies));
            return enemy;
        }
        if (fireMode == AbstractTower.TowerFireMode.Strongest)
        {
            enemy = GetStrongestEnemy(TowerTargets(enemies));
            return enemy;
        }
        return null;
    }

    public void AddNewEnemy(AbstractEnemy enemy)
    {
        _activeEnemies.Add(enemy);
    }
    public void RemoveEnemy(AbstractEnemy enemy)
    {
        _activeEnemies.Remove(enemy);
    }
    
    private AbstractEnemy GetStrongestEnemy(List<AbstractEnemy> enemies)
    {
        AbstractEnemy enemy = null;
        foreach(AbstractEnemy en in enemies)
        {
            if(enemy == null)
            {
                enemy = en;
            }
            else
            {
                if(enemy.Health < en.Health)
                {
                    enemy = en;
                }
            }
        }
        return enemy;
    }

    private AbstractEnemy GetFirstEnemy(List<AbstractEnemy> enemies)
    {
        AbstractEnemy enemy = null;
        foreach(AbstractEnemy en in enemies)
        {
            if(enemy == null)
            {
                enemy = en;
            }
            else
            {
                if(enemy.Distance < en.Distance)
                {
                    enemy = en;
                }
            }
        }
        return enemy;
    }

    private List<AbstractEnemy> TowerTargets(List<AbstractEnemy> enemies)
    {
        List<AbstractEnemy> _targetsToShoot;
         _targetsToShoot = _activeEnemies.FindAll(x => enemies.Contains(x));
        return _targetsToShoot;
    }
}
