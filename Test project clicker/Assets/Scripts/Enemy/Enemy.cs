using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider),typeof(Animator))]
public class Enemy : MonoBehaviour
{
    public UnityAction<Enemy> OnEnemyDied;

    [SerializeField] private int _health;
    [SerializeField] private int _scoreReward;
    [SerializeField] private string _hitAnimationTrigger;
    [SerializeField] private ParticleSystem _deathParticle;

    private List<Transform> _targets = new List<Transform>();
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;

        _animator.SetTrigger(_hitAnimationTrigger);

        if (_health <= 0)
        {
            _health = 0;
            OnEnemyDied?.Invoke(this);
            PlayerScore.Instance.RaiseScore(_scoreReward);

            ParticleSystem deathParticle = Instantiate(_deathParticle, transform.position, Quaternion.identity);
            deathParticle.Play();
            Destroy(deathParticle.gameObject, deathParticle.main.duration);

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
