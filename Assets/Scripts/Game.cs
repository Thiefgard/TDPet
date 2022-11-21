using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class register clicks on field and chack game sustain in a future
public class Game : MonoBehaviour
{
    [SerializeField] private Interraction _interraction;
    
    
    //Get Components from bootstrapper
    public void SetProperties(Interraction interraction)
    {
        _interraction = interraction;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _interraction.GetTile();
        }
    }
}
