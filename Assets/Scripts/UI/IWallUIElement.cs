using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWallUIElement 
{
    bool IsActcive { get; set; }

    void Show(WallTile wallTile);
    void Show();
    void Hide();
}
