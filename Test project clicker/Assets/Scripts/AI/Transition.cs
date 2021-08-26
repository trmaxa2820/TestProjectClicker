using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private State _nextState;

    public State NextState => _nextState;
    public bool NeedTransit { get; protected set; }
    
    protected virtual void OnEnable()
    {
        NeedTransit = false;
    }

}
