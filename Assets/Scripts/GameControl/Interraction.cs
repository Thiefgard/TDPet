using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class For Catching scene Clicks
public class Interraction : MonoBehaviour
{
    private Camera _camera;
    private IInterractable _interractWith;

    private void Start()
    {
        _camera = Camera.main;
    }
   
    public void GetTile()
    {
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 100f);
           
        IInterractable action;
        foreach(var obj in hits)
        {
            action = obj.transform.GetComponent<IInterractable>();
            if (action != null)
            {
               
                if(action == _interractWith)
                {
                    break;
                }
                if (InterractNotNullOrEmpty(action))
                {
                    ChangeInteractObject(action);
                }
                else
                {
                    GetInteract(action);
                }
            }
        }
    }

    private bool InterractNotNullOrEmpty(IInterractable action)
    {
        return _interractWith != null && _interractWith != action;
    }

    private void GetInteract(IInterractable action)
    {
        _interractWith = action;
        action.OnClick();
    }

    private void ChangeInteractObject(IInterractable action)
    {
        
        _interractWith.CancelInterract();
        _interractWith = action;
        GetInteract(action);
    }
}
