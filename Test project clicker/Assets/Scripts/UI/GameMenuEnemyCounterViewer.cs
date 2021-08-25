using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuEnemyCounterViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _enemyCountText;
    [SerializeField] private EnemyCountObserver _enemyCountObserver;
    [SerializeField] private int _maxEnemyCount;

    private void OnEnable()
    {
        _enemyCountObserver.OnEnemyCountChanged += SetEnemyCountText;
    }

    private void OnDisable()
    {
        _enemyCountObserver.OnEnemyCountChanged -= SetEnemyCountText;
    }

    private void Start()
    {
         _enemyCountText.text = "Enemy \n" + 0 + "/" + _maxEnemyCount;
    }

    public void SetEnemyCountText(int enemyCount)
    {
        _enemyCountText.text = "Enemy \n" + enemyCount + "/" + _maxEnemyCount;
    }
}
