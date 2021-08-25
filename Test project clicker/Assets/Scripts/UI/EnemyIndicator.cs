using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyIndicator : MonoBehaviour
{
    [SerializeField] private float _showTime = 3f;
    [SerializeField] private Canvas _indicatorCanvas;
    [SerializeField] private Image _imageIndicator;
    [SerializeField] private Spawner _observerSpawner;
    [SerializeField] private float _multiplyDirectionRect;

    private void OnEnable()
    {
        _observerSpawner.OnEnemySpawn += ShowIndicatorOnEnemy;
    }

    private void OnDisable()
    {
        _observerSpawner.OnEnemySpawn -= ShowIndicatorOnEnemy;
    }

    private Coroutine _currentStartedCorotine;

    private void ShowIndicatorOnEnemy(Enemy enemy)
    {
        if (enemy == null)
            return;

        Vector3 mainCameraPozition  = Camera.main.transform.position;
        Vector3 enemyPozition = enemy.transform.position;

        Vector3 direction = new Vector3(enemyPozition.x - mainCameraPozition.x, enemyPozition.z - mainCameraPozition.z, 0).normalized * _multiplyDirectionRect;

        ShowIndicator(direction);
    }

    public void ShowIndicator(Vector3 uiPozition)
    {
        _indicatorCanvas.gameObject.SetActive(true);

        _imageIndicator.rectTransform.anchoredPosition3D = Vector3.zero;
        _imageIndicator.rectTransform.anchoredPosition3D += uiPozition;

        if (_currentStartedCorotine != null)
        {
            StopCoroutine(_currentStartedCorotine);
        }
            
        _currentStartedCorotine = StartCoroutine(ShowOnTime());

    }

    private IEnumerator ShowOnTime()
    {
        yield return new WaitForSeconds(_showTime);

        _indicatorCanvas.gameObject.SetActive(false);

    }
}
