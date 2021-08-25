using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    [SerializeField] private State _startState;

    private State _currentState;

    public void Update()
    {
        if (_currentState == null)
            return;

        State nextState = _currentState.GetNextState();

        if (nextState == null)
            return;

        Transit(nextState);
        
    }

    private void Start()
    {
        ResetMachine();    
    }

    public void ResetMachine()
    {
        Transit(_startState);
    }

    public void Transit(State state)
    {
        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;
        if (state == null)
            throw new ArgumentException();

        _currentState.Enter();
    }
}
