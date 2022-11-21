using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Factory/TowerFactory")]
public class TowerFactory : ScriptableObject
{
    [SerializeField] private CanonTower _canonTower;
    [SerializeField] private RapidTower _rapidTower;

    public AbstractTower CreateTower(AbstractTower.TowerType type)
    {
        switch (type)
        {
            case AbstractTower.TowerType.Canon:
                return GetTower(_canonTower);
            case AbstractTower.TowerType.RapidArrow:
                return GetTower(_rapidTower);
        }
        return null;
    }

    public void Reclaim(AbstractTower tower)
    {
        Destroy(tower);
    }
    private AbstractTower GetTower(AbstractTower prefab)
    {
        AbstractTower instance = Instantiate(prefab);
        instance.factory = this;
        return instance;
    }
}
