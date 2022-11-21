using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameBootStrapper : MonoBehaviour
{
    public static GameBootStrapper Instance;
    //Init MainGame functionality
    [SerializeField] Game _gamePref;
    //Init current gameBoard;
    [SerializeField] GameBoard _gameBoardPref;
    //Init scene interraction handler
    [SerializeField] private Interraction _interractionPref;
    [SerializeField] private EnemyFactory _enemyFactoryPref;
    [SerializeField] private TowerFactory _towerFactoryPref;
    //Component agregate all enemies on map and help tower find priority target
    [SerializeField] private TargetAnalyzer _analyzerPref;

    private TowerFactory _towerFactory;
    private EnemyFactory _enemyFactory;
    private TargetAnalyzer _analyzer;

    

    private void Start()
    {
        Instance = this;
        _analyzer = Instantiate(_analyzerPref);
        Instantiate(_gameBoardPref);
        Interraction interraction = Instantiate(_interractionPref);
        Instantiate(_gamePref).SetProperties(interraction);
        _enemyFactory = Instantiate(_enemyFactoryPref);
        _towerFactory = Instantiate(_towerFactoryPref);
        
    }

    public TowerFactory GetTowerFactory()
    {
        return _towerFactory;
    }
    public TargetAnalyzer GetTargetAnalyzer()
    {
        return _analyzer;
    }

    public EnemyFactory GetEnemyFactory()
    {
        return _enemyFactory;
    }
}
