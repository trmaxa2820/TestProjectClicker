using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAttack : MonoBehaviour
{
    [SerializeField] protected ParticleSystem AttackParticle;
    [SerializeField] protected int Damage;

    public abstract void Attack(Vector3 mousePozition);
}
