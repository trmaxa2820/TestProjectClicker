using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Enemy> _enemiesTemplate;
    [SerializeField] private List<Transform> _spawnPosition;
    [SerializeField] private float _delayTimeToSpawn;

    public UnityAction<Enemy> OnEnemySpawn;

    private float _timeToSpawn;

    private void Start()
    {
        _timeToSpawn = _delayTimeToSpawn;    
    }

    private void Update()
    {
        _timeToSpawn -= Time.deltaTime;

        if(_timeToSpawn <= 0)
        {
            Spawn();
            _timeToSpawn = _delayTimeToSpawn;
        }
    }

    private void Spawn()
    {
        Enemy enemy = GetRandomElement(_enemiesTemplate);
        enemy.SetTargets(_spawnPosition);
        Vector3 spawnPosition = GetRandomElement(_spawnPosition).position;
        Enemy newEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity, transform);
        newEnemy.SetTargets(_spawnPosition);
        OnEnemySpawn?.Invoke(newEnemy);
    }

    private T GetRandomElement<T>(List<T> listElements)
    {
        int enemylementIndex = Random.Range(0, listElements.Count);

        return listElements[enemylementIndex];
    }
}
