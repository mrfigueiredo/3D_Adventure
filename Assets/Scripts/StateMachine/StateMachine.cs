using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T> where T : System.Enum
{

    public Dictionary<T, StateBase> dictioneryState;

    private StateBase _currentState;

    public void Init()
    {
        dictioneryState = new Dictionary<T, StateBase>();
    }

    public StateBase GetCurrentState
    {
        get { return _currentState; }
    }

    public void RegisterState(T typeEnum, StateBase state)
    {
        dictioneryState.Add(typeEnum, state);
    }

    public void SwitchState(T state, params object[] objs)
    {
        if (_currentState != null)
            _currentState.OnStateExit();

        _currentState = dictioneryState[state];

        _currentState.OnStateEnter(objs);
    }

    private void Update()
    {
        if (_currentState != null)
            _currentState.OnStateStay();
    }
}
