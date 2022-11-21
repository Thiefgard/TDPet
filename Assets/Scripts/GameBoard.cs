using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
//Init and collect tiles from game Field
public class GameBoard : MonoBehaviour
{
    
    [SerializeField] private Vector2Int _boardSize;
    [SerializeField] private float _distanceBetweenTiles = 10f;
    public List<AbstractTile> RoadTiles;
    private Dictionary<AbstractTile, Vector2> _destinationData;
    private AbstractTile[,] _tilesArray;

    private void Start()
    {
        InitField(_boardSize);
    }
    
    private void InitField(Vector2Int size)
    {
        _tilesArray = new AbstractTile[size.x, size.y];
        _destinationData = new Dictionary<AbstractTile, Vector2>();
        foreach (AbstractTile tile in GetComponentsInChildren<AbstractTile>())
        {
            int xPos = (int)(tile.transform.position.x / _distanceBetweenTiles);
            int zPos = (int)(tile.transform.position.z / _distanceBetweenTiles);

            if (tile is DestinationTile)
                _destinationData.Add(tile, new Vector2(xPos, zPos));    
            _tilesArray[xPos, zPos] = tile;
        }
        CheckNeighborsOnRoad(GetDestinationPosition(_destinationData));
    }
    //Find End tiles for monsters
    private Vector2 GetDestinationPosition(Dictionary<AbstractTile, Vector2> destinations)
    {
        
        for (int y = 0; y < _boardSize.y; y++)
        {
            for(int x = 0; x<_boardSize.x; x++)
            {
                if (destinations.ContainsKey(_tilesArray[x, y]))
                {
                    return _destinationData[_tilesArray[x, y]];
                }
            }
        }
        return Vector2.zero;
    }
    //Find and build road
    private void CheckNeighborsOnRoad(Vector2 tilePos)
    {
        int indexX = (int)tilePos.x;
        int indexY = (int)tilePos.y;
        AbstractTile currentTile = _tilesArray[indexX, indexY];
        AbstractTile tileToCheck;
        if (CheckOnArrayRange(indexX + 1))
        {
            tileToCheck = _tilesArray[indexX + 1, indexY];
            CheckOnRoadTile(currentTile, tileToCheck, indexX + 1, indexY);
        }
        if(CheckOnArrayRange(indexX - 1))
        {
            tileToCheck = _tilesArray[indexX - 1, indexY];
            CheckOnRoadTile(currentTile, tileToCheck, indexX - 1, indexY);
        }
        if (CheckOnArrayRange(indexY + 1))
        {
            tileToCheck = _tilesArray[indexX, indexY + 1];
            CheckOnRoadTile(currentTile, tileToCheck, indexX, indexY +1);
        }
        if (CheckOnArrayRange(indexY - 1))
        {
            tileToCheck = _tilesArray[indexX, indexY - 1];
            CheckOnRoadTile(currentTile, tileToCheck, indexX, indexY - 1);
        }
    }

    private void CheckOnRoadTile(AbstractTile currentTile, AbstractTile tileToCheck, int posXToCheck, int posYToCheck)
    {
        if (tileToCheck is RoadTile roadTile)
        {
            if(roadTile._nextOnPath == null)
            {
                roadTile.SetPath(currentTile);
                CheckNeighborsOnRoad(new Vector2(posXToCheck, posYToCheck));
            }
        }
        
    }

    private bool CheckOnArrayRange(int x)
    {
        return x < _boardSize.x && x >= 0;
    }

    
}
