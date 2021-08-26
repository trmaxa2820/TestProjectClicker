using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy),typeof(Animator))]
public class EnemyFXViewer : MonoBehaviour
{
    [SerializeField] private string _hitAnimationTrigger;
    [SerializeField] private ParticleSystem _deathParticle;

    private Enemy _enemy;
    private Animator _animator;

    private void OnEnable()
    {
        _enemy.OnEnemyDied += CreateDiedFX;
        _enemy.OnHealthChanged += PlayHitAnimation;
    }

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        _enemy.OnEnemyDied -= CreateDiedFX;
        _enemy.OnHealthChanged -= PlayHitAnimation;
    }

    public void PlayHitAnimation()
    {
        _animator.SetTrigger(_hitAnimationTrigger);
    }

    public void CreateDiedFX(Enemy enemy)
    {
        ParticleSystem deathParticle = Instantiate(_deathParticle, transform.position, Quaternion.identity);
        deathParticle.Play();
        Destroy(deathParticle.gameObject, deathParticle.main.duration);
    }
}
