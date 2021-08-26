using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyCountObserver : MonoBehaviour
{
    public event Action<int> OnEnemyCountChanged;

    [SerializeField] private Spawner _enemySpawner;

    private List<Enemy> _listeningEnemy = new List<Enemy>();

    public int EnemyCount { get; private set; }

    private void OnEnable()
    {
        _enemySpawner.OnEnemySpawn += IncreaseEnemyCount;
    }

    private void OnDisable()
    {
        _enemySpawner.OnEnemySpawn -= IncreaseEnemyCount;

        foreach (Enemy enemy in _listeningEnemy)
            enemy.OnEnemyDied -= DecreaseEnemyCount;
    }

    private void IncreaseEnemyCount(Enemy enemy)
    {
        enemy.OnEnemyDied += DecreaseEnemyCount;
        EnemyCount += 1;
        _listeningEnemy.Add(enemy);
        OnEnemyCountChanged?.Invoke(EnemyCount);
    }

    private void DecreaseEnemyCount(Enemy enemy)
    {
        enemy.OnEnemyDied -= DecreaseEnemyCount;
        EnemyCount -= 1;
        _listeningEnemy.Remove(enemy);
        OnEnemyCountChanged?.Invoke(EnemyCount);
    }
}
