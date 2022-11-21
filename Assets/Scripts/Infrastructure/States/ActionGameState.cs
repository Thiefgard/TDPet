using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionGameState : IState
{
    private SceneLoader _sceneLoader;
    public ActionGameState(SceneLoader loader)
    {
        _sceneLoader = loader;
    }
    public void Enter()
    {
        _sceneLoader.Load(ScenesList.ActionScene);
    }

    public void Exit()
    {
    }
}
