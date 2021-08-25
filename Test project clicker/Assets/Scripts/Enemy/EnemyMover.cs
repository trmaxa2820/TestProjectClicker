using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Enemy),typeof(NavMeshAgent))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _acceleration;

    private Vector3 _targetPosition;
    private Enemy _enemy;
    private NavMeshAgent _navMeshAgent;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _enemy = GetComponent<Enemy>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = _moveSpeed;
        _navMeshAgent.acceleration = _acceleration;
    }

    public void Move(Vector3 targetPosition)
    {
        if (_targetPosition == targetPosition)
            return;

        _navMeshAgent.SetDestination(targetPosition);
    }

}
