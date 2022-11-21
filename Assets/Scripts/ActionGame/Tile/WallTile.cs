using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WallTile : AbstractTile, IInterractable
{
    [SerializeField] private TowerFactory _factory;
    [SerializeField] private WallTileBuilder _builder;
    private IWallUIElement _tileUI;
    public AbstractTower _tower;

    public bool IsEmpty { get; }
    private void Start()
    {
        _tileUI = GetComponentInChildren<IWallUIElement>();
        _factory = GameBootStrapper.Instance.GetTowerFactory();

    }
    public void OnClick()
    {
        if (!_tileUI.IsActcive)
        {
            if (_tower)
            {
                _tileUI.Show(this);
            }
            else
            {
                _tileUI.Show();
            }
        }
        else
        {
            _tileUI.Hide();
        }
    }

    public void CancelInterract()
    {
        _tileUI.Hide();
    }
    public AbstractTower.TowerType GetTowerType()
    {
        return _tower.Type;
    }
    public void CreateTower(AbstractTower.TowerType type)
    {
        if(_tower == null)
        {
            _tower = _builder.Build(type, _factory, this);
            _tileUI.Hide();
            _tileUI.Show(this);
        }
        
    }
    public void DestoyTower()
    {
        if (_tower != null)
        {
            _builder.DestroyBuild(_tower);
            _tileUI.Hide();
            _tileUI.Show();
        }
    }
}
