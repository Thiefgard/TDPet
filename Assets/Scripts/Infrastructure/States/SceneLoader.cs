
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader 
{
    private ICoroutineRunner _coroutine;
    private LoadingCurtain _curtain;
    public SceneLoader(ICoroutineRunner coroutine, LoadingCurtain curtain)
    {
        _coroutine = coroutine;
        _curtain = curtain;
    }
  
    public void Load(string sceneName, Action onLoad = null)
    {
        _curtain.Show();
        _coroutine.StartCoroutine(LoadScene(sceneName, _curtain.Hide));
    }
    private IEnumerator LoadScene(string sceneName, Action onLoad = null)
    {
        AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(sceneName);
        while (!waitNextScene.isDone)
            yield return null;
        onLoad?.Invoke();
    }
}
