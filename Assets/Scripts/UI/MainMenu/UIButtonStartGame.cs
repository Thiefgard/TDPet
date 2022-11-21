using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonStartGame : MonoBehaviour
{
    public void OnClick()
    {
        StateMachineController.Instance.StartGame();
    }
}
