using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover),typeof(Enemy))]
public class MoveState : State
{
    private EnemyMover _enemyMover;

    public Vector3 CurrentWayPoint { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnEnable()
    {
        CurrentWayPoint = GetRandomWayPoint();
        _enemyMover.Move(CurrentWayPoint);
        _animator.SetBool(_animationTrigger, true);
    }

    private void OnDisable()
    {
        _animator.SetBool(_animationTrigger, false);
    }

    private Vector3 GetRandomWayPoint()
    {
        Transform wayPoint = _enemy.GetRandomTargets();

        return wayPoint.position;
    }
}
