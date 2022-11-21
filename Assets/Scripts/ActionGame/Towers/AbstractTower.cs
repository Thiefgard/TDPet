using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbstractTower : MonoBehaviour
{
    public enum TowerType
    {
        Canon,
        RapidArrow
    }
    //Enum For switch target proirity
    public enum TowerFireMode
    {
        First,
        Strongest
    }
    [SerializeField] protected float _towerRange;
    [SerializeField] protected float _towerFireRate;
    [SerializeField] protected int _towerDamage;
    public TowerType Type;
    public TowerFactory factory;
    protected virtual void Shoot()
    {

    }

}
