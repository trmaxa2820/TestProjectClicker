using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultPlayerAttack : PlayerAttack
{
    public override void Attack(Vector3 mousePozition)
    {
        Ray ray = Camera.main.ScreenPointToRay(mousePozition);

        if (Physics.Raycast(ray, out RaycastHit hit, 300f))
        {
            if (hit.collider.TryGetComponent<Enemy>(out Enemy enemy))
            {
                AttackParticle.gameObject.transform.position = hit.point;
                AttackParticle.Play();
                enemy.TakeDamage(Damage);
            }
        }
    }
}
