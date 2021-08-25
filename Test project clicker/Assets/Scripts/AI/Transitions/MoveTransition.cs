using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MoveState))]
public class MoveTransition : Transition
{
    [SerializeField] private float _rangeDistance;

    private MoveState _moveState;

    private void Awake()
    {
        _moveState = GetComponent<MoveState>();
    }

    private void Update()
    {
        if (NeedTransit)
            return;

        if (Vector3.Distance(_moveState.CurrentWayPoint, transform.position) <= _rangeDistance)
            NeedTransit = true;
    }
}
