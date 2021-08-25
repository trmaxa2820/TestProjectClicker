using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameMenuScoreViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private PlayerScore _playerScore;

    private void OnEnable()
    {
        _playerScore.OnScoreChanged += SetScoreText;
    }

    private void OnDisable()
    {
        _playerScore.OnScoreChanged -= SetScoreText;
    }

    public void SetScoreText(int score)
    {
        _scoreText.text = "Score: " + score;
    }
}
