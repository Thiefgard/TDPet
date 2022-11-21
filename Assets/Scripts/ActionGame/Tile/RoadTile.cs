using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadTile : AbstractTile, IInterractable
{
   
    [SerializeField] private Transform _arrow;
    [SerializeField] private float _distanceBetweenTile;
    public float DestinationValue = 0;
    //next tile on road to destination
    public AbstractTile _nextOnPath;

    public bool HasPath => _nextOnPath != null;

    //Set next tile in gameboard by order
    public void SetPath(AbstractTile tile)
    {
        _nextOnPath = tile;
        if (tile is RoadTile roadTile)
        {
            DestinationValue = roadTile.DestinationValue + _distanceBetweenTile;
        }
        InitPathDirection();
    }

    private void InitPathDirection()
    {
        var arrow = Instantiate(_arrow);
        arrow.transform.parent = this.gameObject.transform;
        arrow.transform.position = this.gameObject.transform.position;
        var direction = _nextOnPath.transform.position - transform.position;
        arrow.transform.rotation = Quaternion.LookRotation(direction);
    }

    public float GetDestinationValue()
    {
        return DestinationValue;
    }
    public Transform GetTileToMove()
    {
        return _nextOnPath.transform;
    }
    public void OnClick()
    {
        
    }

    public void CancelInterract()
    {
    }
}
