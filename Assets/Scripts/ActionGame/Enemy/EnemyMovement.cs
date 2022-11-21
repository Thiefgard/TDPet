using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private AbstractEnemy _enemyToMove;
    private float speed;

    private void Start()
    {
        _enemyToMove = GetComponent<AbstractEnemy>();
    }

    private void Update()
    {
        
        if (_enemyToMove.Destination == null)
        {
            GetNextDestinationPoint();
        }
        else
        {
            if (IsNearDestination(_enemyToMove.Destination))
            {
                GetNextDestinationPoint();
            }
            MoveTo(_enemyToMove.Destination);
            
        }
        
    }

    private void MoveTo(Transform destination)
    {
        speed = _enemyToMove.Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destination.position, speed);
    }

    private void GetNextDestinationPoint()
    {
        _enemyToMove.Destination = _enemyToMove.NextTarget();
    }

    private bool IsNearDestination(Transform destination)
    {
        _enemyToMove.Distance += speed;
        return Vector3.Distance(transform.position, destination.position) < 1f;
            
    }
}
