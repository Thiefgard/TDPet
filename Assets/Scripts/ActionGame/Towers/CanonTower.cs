using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class CanonTower : AbstractTower
{
    [SerializeField] private TowerFireMode _mode;
    [SerializeField] private Canon _canon;
    [SerializeField] private Transform _launchCanonPos;
    [SerializeField] private TargetAnalyzer _targetAnalyzer;
    private SphereCollider _rangeCollider;
    public List<AbstractEnemy> _targetList = new List<AbstractEnemy>();
    private float _cooldownTime = 0;
    [SerializeField] AbstractEnemy _targetEnemy;


    private void Start()
    {
        _targetAnalyzer = GameBootStrapper.Instance.GetTargetAnalyzer();
        _rangeCollider = GetComponent<SphereCollider>();
        _rangeCollider.isTrigger = true;
        _rangeCollider.radius = _towerRange;
        _cooldownTime = _towerFireRate;
    }

    private void Update()
    {
        _cooldownTime += Time.deltaTime;
        if(_targetList.Count > 0 && _cooldownTime > _towerFireRate)
        {
            Shoot();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        AbstractEnemy target = other.GetComponent<AbstractEnemy>();
        if(target != null)
        {
            _targetList.Add(target);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        AbstractEnemy target = other.GetComponent<AbstractEnemy>();
        if (target != null)
        {
            _targetList.Remove(target);
        }
    }
    protected override void Shoot()
    {
        _targetEnemy = _targetAnalyzer.GetEnemyTarget(_targetList, _mode);
        print(_targetEnemy.Distance);
        _cooldownTime = 0;
        Canon canon = Instantiate(_canon);
        canon.transform.position = new Vector3(_launchCanonPos.transform.position.x, _launchCanonPos.transform.position.y + 5f, _launchCanonPos.transform.position.z);
        canon.Fire(canon.transform.position, _targetEnemy.transform.position, _towerDamage);
    }

   
}
