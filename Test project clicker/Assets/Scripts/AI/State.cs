using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] protected List<Transition> _transitions;
    [SerializeField] protected string _animationTrigger;

    protected Enemy _enemy;
    protected Animator _animator;

    protected virtual void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();

    }

    public void Enter()
    {
        enabled = true;
        foreach (Transition transition in _transitions)
            transition.enabled = true;
    }

    public void Exit()
    {
        foreach (Transition transition in _transitions)
            transition.enabled = false;
        enabled = false;
    }

    public State GetNextState()
    {
        foreach(Transition transition in _transitions)
        {
            if (transition.NeedTransit)
                return transition.NextState;
        }

        return null;
    }
}
