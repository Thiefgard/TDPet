using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//patter for every type of tower or empty tile for generating buttons
[CreateAssetMenu(menuName = "WallUI/UIType")]
public class UIWallContent : ScriptableObject
{
    public UIWall.UIContent Content;

    public Button TopButton;
    public Button TopLeftButton;
    public Button TopRightButton;
    public Button DownRightButton;
    public Button DownLeftButton;
}
