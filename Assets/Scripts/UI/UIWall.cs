using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Show UI by click. Instantiatie Buttons for every type of tower or empty wall
public class UIWall : MonoBehaviour, IWallUIElement
{
    public enum UIContent
    {
        CanonTower,
        RappidTower,
        None
    }
    [SerializeField] private Canvas _canvas;

    [SerializeField] private Transform _top;
    [SerializeField] private Transform _topLeft;
    [SerializeField] private Transform _topRight;
    [SerializeField] private Transform _downRight;
    [SerializeField] private Transform _downleft;

    [SerializeField] private List<UIWallContent> _uiContents;
    [SerializeField] private UIContent _tileUiContent;

    private List<Button> _buttons = new List<Button>();
    private WallTile _wallTile;
    
    public bool IsActcive { get; set; }

    private void Start()
    {
        
    }
    public void Show(WallTile wallTile)
    {
        IsActcive = true;
        _canvas.gameObject.SetActive(true);
        _wallTile = wallTile;
        SetUIContentType(wallTile.GetTowerType());
        InitButtons();
    }
    public void Show()
    {
        IsActcive = true;
        _canvas.gameObject.SetActive(true);
        _tileUiContent = UIContent.None;
        _wallTile = null;
        InitButtons();
    }
    
    public void Hide()
    {
        IsActcive = false;
        _canvas.gameObject.SetActive(false);
        DestroyButtons();
    }
   
    private void SetUIContentType(AbstractTower.TowerType type)
    {
        if (type == AbstractTower.TowerType.Canon)
        {
            _tileUiContent = UIContent.CanonTower;
        }
        if (type == AbstractTower.TowerType.RapidArrow)
        {
            _tileUiContent = UIContent.RappidTower;
        }
    }
    
    private void InitButtons()
    {
        foreach (UIWallContent content in _uiContents)
        {
            if (content.Content == _tileUiContent)
            {
                Button buttonTop = SetUiButton(content.TopButton, _top);
                Button buttonTopRight = SetUiButton(content.TopRightButton, _topRight);
                Button buttonTopLedt = SetUiButton(content.TopLeftButton, _topLeft);
                Button buttonDownLeft = SetUiButton(content.DownLeftButton, _downleft);
                Button button_DownRight = SetUiButton(content.DownRightButton, _downRight);
            }
        }
    }
    
    private void DestroyButtons()
    {
        for (int i = 0; i < _buttons.Count; i++)
        {
            Destroy(_buttons[i].gameObject);
        }
        _buttons.Clear();
    }

    private Button SetUiButton(Button button, Transform buttonTransform)
    {
        if(button != null)
        {
            Button tmpButton = Instantiate(button, buttonTransform);
            tmpButton.transform.position = buttonTransform.position;
            _buttons.Add(tmpButton);
            WallTile tile = tmpButton.GetComponentInParent<WallTile>();
            tmpButton.GetComponent<IButton>().GetTile(tile);
            return tmpButton;
        }
        return null;
    }

}
