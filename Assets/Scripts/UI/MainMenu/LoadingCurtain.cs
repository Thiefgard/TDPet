using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingCurtain : MonoBehaviour
{
    [SerializeField] private float _curtainAlphaSpeed = 0.02f;
    [SerializeField] private float _curtainHideSpeed = 0.03f;

    [SerializeField]private CanvasGroup _curtain;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void Show()
    {
        _curtain.gameObject.SetActive(true);
        _curtain.alpha = 1;
    }

    public void Hide() =>
        StartCoroutine(HideCurtain());
    private IEnumerator HideCurtain()
    {
        while(_curtain.alpha > 0)
        {
            _curtain.alpha -= _curtainAlphaSpeed;
            yield return new WaitForSeconds(_curtainHideSpeed);
        }
        gameObject.SetActive(false);
    }
}
