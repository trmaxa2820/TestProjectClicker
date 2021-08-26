using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public abstract class State : MonoBehaviour
{
    [SerializeField] protected List<Transition> Transitions;
    [SerializeField] protected string AnimationTriger;

    protected Enemy Enemy;
    protected Animator Animator;

    protected virtual void Awake()
    {
        Enemy = GetComponent<Enemy>();
        Animator = GetComponent<Animator>();

    }

    public void Enter()
    {
        enabled = true;
        foreach (Transition transition in Transitions)
            transition.enabled = true;
    }

    public void Exit()
    {
        foreach (Transition transition in Transitions)
            transition.enabled = false;
        enabled = false;
    }

    public State GetNextState()
    {
        foreach(Transition transition in Transitions)
        {
            if (transition.NeedTransit)
                return transition.NextState;
        }

        return null;
    }
}
