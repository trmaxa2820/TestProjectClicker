using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider),typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> OnEnemyDied;
    public event UnityAction OnHealthChanged;

    [SerializeField] private int _health;
    [SerializeField] private int _scoreReward;

    private List<Transform> _targets = new List<Transform>();

    public void TakeDamage(int damage)
    {
        _health -= damage;
        OnHealthChanged?.Invoke();

        if (_health <= 0)
        {
            _health = 0;
            OnEnemyDied?.Invoke(this);
            PlayerScore.Instance.RaiseScore(_scoreReward);
            Destroy(this.gameObject);
        }
            
    }

    public void SetTargets(List<Transform> targets)
    {
        _targets = targets;
    }

    public Transform GetRandomTargets()
    {
        int targetIndex = Random.Range(0, _targets.Count);

        return _targets[targetIndex];
    }
}
