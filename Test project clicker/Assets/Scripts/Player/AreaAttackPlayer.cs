using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class AreaAttackPlayer : PlayerAttack
{
    [SerializeField] private float _radiusAttackArea;
    [SerializeField] private float _delayAttackTime;

    private Coroutine _attackCoroutine;

    private void Start()
    {
        ShapeModule attackParticleShape = AttackParticle.shape;
        attackParticleShape.radius = _radiusAttackArea;
    }

    public override void Attack(Vector3 mousePozition)
    {
        if (_attackCoroutine != null)
            return;

        Ray ray = Camera.main.ScreenPointToRay(mousePozition);

        if(Physics.Raycast(ray, out RaycastHit mouseHit, 300f))
        {
            AttackParticle.gameObject.transform.position = mouseHit.point;
            AttackParticle.Play();
        }

        RaycastHit[] hits = Physics.SphereCastAll(ray, _radiusAttackArea, 300f);

        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                enemy.TakeDamage(Damage);
            }
        }

        _attackCoroutine = StartCoroutine(StartAttackDelay());
    }

    private IEnumerator StartAttackDelay()
    {
        yield return new WaitForSeconds(_delayAttackTime);

        _attackCoroutine = null;
    }
}
