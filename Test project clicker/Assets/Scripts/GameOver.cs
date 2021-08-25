using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private EnemyCountObserver _enemyCountObserver;
    [SerializeField] private GameObject _endGamePanel;
    [SerializeField] private int _maxEnemyCount;

    private void OnEnable()
    {
        _enemyCountObserver.OnEnemyCountChanged += CheckEnemyCount;
    }

    private void OnDisable()
    {
        _enemyCountObserver.OnEnemyCountChanged -= CheckEnemyCount;
    }

    private void CheckEnemyCount(int enemyCount)
    {
        if(enemyCount > _maxEnemyCount)
        {
            Time.timeScale = 0f;
            _endGamePanel.SetActive(true);
        }
    }
}
