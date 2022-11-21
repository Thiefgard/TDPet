using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Controller of global states of the game
public class StateMachineController : MonoBehaviour, ICoroutineRunner
{
    public static StateMachineController Instance;
    [SerializeField] private LoadingCurtain _curtain;
    private GameStateMachine _stateMachine;

    public Action ChangeSTateEvent;
    [SerializeField] private SceneLoader _loader;
    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }
    private void Start()
    {
        _stateMachine = new GameStateMachine(new SceneLoader(this, _curtain));

        _stateMachine.EnterToState<MainMenuState>();
    }

    public void StartGame()
    {
        _stateMachine.EnterToState<ActionGameState>();
    }
}
