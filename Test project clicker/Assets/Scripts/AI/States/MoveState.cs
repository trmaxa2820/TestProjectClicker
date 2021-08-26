using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(EnemyMover),typeof(Enemy))]
public class MoveState : State
{
    private EnemyMover _enemyMover;

    public Vector3 CurrentWayPoint { get; private set; }

    private void OnEnable()
    {
        CurrentWayPoint = GetRandomWayPoint();
        _enemyMover.Move(CurrentWayPoint);
        Animator.SetBool(AnimationTriger, true);
    }

    protected override void Awake()
    {
        base.Awake();
        _enemyMover = GetComponent<EnemyMover>();
    }

    private void OnDisable()
    {
        Animator.SetBool(AnimationTriger, false);
    }

    private Vector3 GetRandomWayPoint()
    {
        Transform wayPoint = Enemy.GetRandomTargets();

        return wayPoint.position;
    }
}
