using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Global states of game
public class GameStateMachine
{

    private Dictionary<Type, IState> _states;
    private IState _currentState;
    private SceneLoader _loader;

    public GameStateMachine(SceneLoader loader)
    {
        //_loader = loader;   
        _states = new Dictionary<Type, IState>()
        {
            [typeof(MainMenuState)] = new MainMenuState(loader),
            [typeof(ActionGameState)] = new ActionGameState(loader)
        };
       
    }

    public void EnterToState<TState>() where TState : class, IState
    {
        IState state = ChangeState<TState>();
        state.Enter();
    }

    public TState ChangeState<TState>() where TState : class, IState
    {
        _currentState?.Exit();
        TState state = GetState<TState>();
        _currentState = state;
        return state;
    }

    public TState GetState<TState>() where TState : class, IState
    {
        TState state = _states[typeof(TState)] as TState;
        return state;
    }

}
